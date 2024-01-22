CREATE DATABASE DBFUNKOPOP;

GO

CREATE TABLE PROVINCE (
    idProvince INT IDENTITY PRIMARY KEY,
    name VARCHAR(25) NOT NULL
);
GO

CREATE TABLE CITY (
    idCity INT IDENTITY PRIMARY KEY,
    postal_code VARCHAR(8) NOT NULL,
    name VARCHAR(50) NOT NULL,
    idProvince INT NOT NULL REFERENCES PROVINCE(idProvince)
);
GO

--CREATE TABLE ADDRESS (
--    idAddress INT IDENTITY PRIMARY KEY,
--    street_name VARCHAR(30) NOT NULL,
--    street_number INT NOT NULL,
--    floor INT,
--    department VARCHAR(5),
--    idCity INT NOT NULL REFERENCES CITY(idCity),
--    active BIT DEFAULT 1 NOT NULL
--);
--GO

CREATE TABLE COLLECTION (
    idCollection INT IDENTITY PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    description VARCHAR(999) NOT NULL,
    active BIT DEFAULT 1,
    url_image VARCHAR(400),
    ref_image VARCHAR(100),
	registerdate DATETIME DEFAULT GETDATE()
);
GO

CREATE TABLE PRODUCT (
    idProduct INT IDENTITY PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    description VARCHAR(999) NOT NULL,
    price DECIMAL(10,2) DEFAULT 0,
    stock INT NOT NULL,
    shine BIT NOT NULL DEFAULT 0,
    idCollection INT REFERENCES collection(idCollection),
    active BIT DEFAULT 1 NOT NULL,
    url_image VARCHAR(400),
    ref_image VARCHAR(100),
	registerdate DATETIME DEFAULT GETDATE()
);
GO

CREATE TABLE CLIENT (
    idClient INT IDENTITY PRIMARY KEY,
    lastname VARCHAR(100) NOT NULL CHECK (lastname NOT LIKE '%[^a-zA-Z]%'),
    firstname VARCHAR(100) NOT NULL CHECK (firstname NOT LIKE '%[^a-zA-Z]%'),
    email VARCHAR(100) UNIQUE NOT NULL CHECK (email LIKE '%_@__%.__%'),
	password VARCHAR(150),
	reboot BIT DEFAULT 0,
	registerdate DATETIME DEFAULT GETDATE()
);
GO

CREATE TABLE CART (
    idCart INT IDENTITY PRIMARY KEY,
    idClient INT REFERENCES CLIENT(idClient),
    idProduct INT REFERENCES PRODUCT(idProduct),
	amount INT
);
GO

CREATE TABLE SALE (
    idSale INT IDENTITY PRIMARY KEY,
	idClient INT REFERENCES CLIENT(idClient),
	amount_products INT,
    payment_total DECIMAL(10,2),
	contact VARCHAR(50),
	idCity INT REFERENCES CITY(idCity),
	phone VARCHAR(50),
	address VARCHAR (500),
    idTransaction VARCHAR(50),
    saleDate DATETIME DEFAULT GETDATE()
);
GO

CREATE TABLE SALE_DETAIL (
    idSaleDetail INT IDENTITY PRIMARY KEY,
    idSale INT REFERENCES SALE(idSale),
    idProduct INT REFERENCES PRODUCT(idProduct),
	amount INT,
    total DECIMAL(10,2)
);
GO

CREATE TABLE [USER] (
    idUser INT IDENTITY PRIMARY KEY,
    lastname VARCHAR(100) NOT NULL CHECK (lastname NOT LIKE '%[^a-zA-Z]%'),
    firstname VARCHAR(100) NOT NULL CHECK (firstname NOT LIKE '%[^a-zA-Z]%'),
    email VARCHAR(100) UNIQUE NOT NULL CHECK (email LIKE '%_@__%.__%'),
	password VARCHAR(150),
	reboot BIT DEFAULT 1,
	active BIT DEFAULT 1,
	registerdate DATETIME DEFAULT GETDATE()
);
GO

--CREATE TABLE consultation_product (
--    id INT IDENTITY(1,1) PRIMARY KEY,
--    message VARCHAR(999) NOT NULL,
--    response VARCHAR(999),
--    product_id INT NOT NULL REFERENCES product(id),
--    user_id INT NOT NULL REFERENCES [user](id),
--    active BIT DEFAULT 1 NOT NULL
--);
--GO

--CREATE TABLE favorite (
--    id INT PRIMARY KEY IDENTITY,
--    product_id INT NOT NULL REFERENCES product(id),
--    user_id INT NOT NULL REFERENCES [user](id)
--);
--GO

create procedure sp_AddUser(
    @lastname VARCHAR(100),
    @firstname VARCHAR(100),
    @email VARCHAR(100),
	@password VARCHAR(150),
	@active BIT,
	@Message VARCHAR(500),
	@Result INT OUTPUT
)
AS
BEGIN
	SET @Result = 0
	IF NOT EXISTS (SELECT * FROM [USER] WHERE email = @email)
	BEGIN
		INSERT INTO [DBFUNKOPOP].[dbo].[USER] (lastname, firstname, email, password, active) VALUES (@lastname, @firstname, @email, @password, @active)
		SET @Result = scope_identity()
	END
	ELSE
		SET @Message = 'El email ya existe'
END

create procedure sp_Edit(
	@idUser INT,
    @lastname VARCHAR(100),
    @firstname VARCHAR(100),
    @email VARCHAR(100),
	@active BIT,
	@Message VARCHAR(500),
	@Result INT OUTPUT
)
AS
BEGIN
	SET @Result = 0
	IF NOT EXISTS (SELECT * FROM [USER] WHERE email = @email AND idUser != @idUser)
	BEGIN
		UPDATE TOP (1) [USER] SET
		lastname = @lastname,
	 	firstname = @firstname,
		email= @email,
		active = @active
		WHERE idUser = @idUser
		SET @Result = 1
	END
	ELSE
		SET @Message = 'El email ya existe'
END