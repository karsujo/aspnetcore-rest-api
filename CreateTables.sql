
CREATE TABLE [dbo].[authors] (
    [au_id]    VARCHAR(40)   NOT NULL,
    [au_lname] VARCHAR (40) NOT NULL,
    [au_fname] VARCHAR (40) NOT NULL,
    [phone]    CHAR (12)    DEFAULT ('UNKNOWN') NOT NULL,
    [address]  VARCHAR (100) NULL,
    [city]     VARCHAR (20) NULL,
    [state]    CHAR (2)     NULL,
    [zip]      CHAR (5)     NULL,
    CONSTRAINT [UPKCL_auidind] PRIMARY KEY CLUSTERED ([au_id] ASC),
    CHECK ([zip] like '[0-9][0-9][0-9][0-9][0-9]')
);


CREATE TABLE [dbo].[books] (
    [au_id]   VARCHAR(40)    NOT NULL,
    [book_id]  VARCHAR(40)   NOT NULL,
    [title]     VARCHAR (80)  NOT NULL,
    [type]      CHAR (12)     DEFAULT ('UNDECIDED') NOT NULL,
    [price]     MONEY         NULL,
    [pubdate]   DATETIME      DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [UPKCL_booksidind] PRIMARY KEY CLUSTERED ([book_id] ASC),
	 FOREIGN KEY ([au_id]) REFERENCES [dbo].[authors] ([au_id]),
);


CREATE TABLE [dbo].[sales] (
    [ord_id]     VARCHAR (20) NOT NULL,
    [ord_date]   DATETIME     NOT NULL,
    [qty]        SMALLINT     NOT NULL,
    [pay_amount] MONEY  NOT NULL,
    [pay_method] VARCHAR (12) NOT NULL,
    [book_id]    VARCHAR (40) NOT NULL,
    CONSTRAINT [UPKCL_sales] PRIMARY KEY CLUSTERED ([ord_id] ASC, [book_id] ASC),
    FOREIGN KEY ([book_id]) REFERENCES [dbo].[books] ([book_id])
);