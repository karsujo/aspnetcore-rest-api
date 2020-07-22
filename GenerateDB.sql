
CREATE TABLE [dbo].[authors] (
    [au_id]    VARCHAR(40)   NOT NULL,
    [au_lname] VARCHAR (40) NOT NULL,
    [au_fname] VARCHAR (20) NOT NULL,
    [phone]    CHAR (12)    DEFAULT ('UNKNOWN') NOT NULL,
    [address]  VARCHAR (40) NULL,
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

--Insert seed values

DECLARE @au_guid varchar(40);
DECLARE @bk_guid varchar(40);

SET @au_guid = NEWID();
SET @bk_guid = NEWID();

insert authors values(@au_guid, 'Bennet', 'Abraham', '415 658-9932', '6223 Bateman St.', 'Berkeley', 'CA', '94705')
insert books values (@au_guid ,@bk_guid, 'Secrets of Silicon Valley', 'nonfic_tech', $20.00, '06/12/94')
insert sales values(NEWID(), '09/14/94', 1, $10, 'Cash',@bk_guid)

SET @au_guid = NEWID();
SET @bk_guid = NEWID();

insert authors values(@au_guid, 'Green', 'Marjorie', '415 986-7020','309 63rd St. #411', 'Oakland', 'CA', '94618')
insert books values (@au_guid ,@bk_guid, 'Blood Diamond', 'fic_action', $10.00, '06/15/91')
insert sales values(NEWID(), '09/14/94', 1, $10, 'Cash',@bk_guid)

SET @au_guid = NEWID();
SET @bk_guid = NEWID();

insert authors values(@au_guid, 'Carson', 'Cheryl', '415 548-7723', '589 Darwin Ln.', 'Berkeley', 'CA', '94705')
insert books values (@au_guid ,@bk_guid, 'The Terapose Secret', 'fic_history', $10.00, '07/12/84')
insert books values (@au_guid ,NEWID(), 'The Summary of Nonce', 'fic_tech', $20.00, '01/12/90')
insert books values (@au_guid ,NEWID(), 'About the Bullwhipper', 'fic_western', $10.00, '06/11/91')
insert sales values(NEWID(), '09/14/94', 2, $10, 'Card',@bk_guid)



SET @au_guid = NEWID();
SET @bk_guid = NEWID();

insert authors values(@au_guid, 'Ringer', 'Albert', '801 826-0752','67 Seventh Av.', 'Salt Lake City', 'UT', '84152')
insert books values (@au_guid ,@bk_guid, 'The Problematic Coder', 'nonfic_tech', $15.00, '01/12/88')
insert sales values(NEWID(), '09/14/94', 3, $10, 'Cash',@bk_guid)


SET @au_guid = NEWID();
SET @bk_guid = NEWID();

insert authors values(@au_guid, 'Ringer', 'Anne', '801 826-0752', '67 Seventh Av.', 'Salt Lake City', 'UT', '84152')
insert books values (@au_guid ,@bk_guid, 'The Stormlight Chronicles I', 'fic_fantasy', $20.00, '06/10/94')
insert books values (@au_guid ,NEWID(), 'The Stormlight Chronicles II', 'fic_fantasy', $20.00, '08/12/99')
insert books values (@au_guid ,NEWID(), 'The Stormlight Chronicles III', 'fic_fantasy', $20.00, '01/12/90')
insert sales values(NEWID(), '09/14/94', 2, $10, 'Card',@bk_guid)



SET @au_guid = NEWID();
SET @bk_guid = NEWID();

insert authors values(@au_guid, 'DeFrance', 'Michel', '219 547-9982', '3 Balding Pl.', 'Gary', 'IN', '46403')
insert books values (@au_guid ,@bk_guid, 'The Clone Wars I', 'fic_sci', $20.00, '06/01/92')
insert books values (@au_guid ,NEWID(), 'The Clone Wars Reloaded', 'fic_sci', $20.00, '09/12/99')
insert sales values(NEWID(), '09/14/94', 15, $5, 'Card',@bk_guid)


SET @au_guid = NEWID();
SET @bk_guid = NEWID();

insert authors values(@au_guid, 'Panteley', 'Sylvia', '301 946-8853', '1956 Arlington Pl.', 'Rockville', 'MD', '20853')
insert books values (@au_guid ,@bk_guid, 'The Brain :Explained', 'nonfic_psych', $20.00, '09/12/87')
insert sales values(NEWID(), '09/14/94', 1, $20, 'Cash',@bk_guid)

  