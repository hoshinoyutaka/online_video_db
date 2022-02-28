 
CREATE TABLE [User]
( 
	[User_nickname]      nchar(45)  NOT NULL ,
	[User_email]         nchar(45)  NOT NULL ,
	[User_password]      nchar(45)  NOT NULL ,
	[User_surname]       nchar(45)  NOT NULL ,
	[User_name]          nchar(45)  NOT NULL ,
	[User_country]       nchar(45)  NOT NULL ,
	[User_phone]         nchar(45)  NULL ,
	[User_picture]       nchar(255)  NULL ,
	[User_ID]            tinyint  NOT NULL ,
	 PRIMARY KEY  CLUSTERED ([User_ID] ASC)
)
go

CREATE TABLE [Category]
( 
	[Category_ID]        tinyint  NOT NULL ,
	[Category_title]     nchar(25)  NOT NULL ,
	 PRIMARY KEY  CLUSTERED ([Category_ID] ASC)
)
go

CREATE TABLE [Privacy]
( 
	[Privacy_ID]         tinyint  NOT NULL ,
	[Privacy_title]      nchar(25)  NOT NULL ,
	 PRIMARY KEY  CLUSTERED ([Privacy_ID] ASC)
)
go

CREATE TABLE [Video]
( 
	[Video_name]         nchar(100)  NOT NULL ,
	[Video_description]  nchar(255)  NULL ,
	[Video_timestamp]    datetime  NOT NULL ,
	[Video_cover]        nchar(255)  NULL ,
	[Video_ID]           tinyint  NOT NULL ,
	[User_ID]            tinyint  NOT NULL ,
	[Category_ID]        tinyint  NOT NULL DEFAULT 0,
	[Privacy_ID]         tinyint  NOT NULL DEFAULT 0,
	[Video_link]         nchar(255)  NOT NULL ,
	 PRIMARY KEY  CLUSTERED ([Video_ID] ASC),
	 FOREIGN KEY ([User_ID]) REFERENCES [User]([User_ID])
		ON DELETE CASCADE
		ON UPDATE CASCADE,
 FOREIGN KEY ([Category_ID]) REFERENCES [Category]([Category_ID])
		ON DELETE SET DEFAULT
		ON UPDATE CASCADE,
 FOREIGN KEY ([Privacy_ID]) REFERENCES [Privacy]([Privacy_ID])
		ON DELETE SET DEFAULT
		ON UPDATE NO ACTION
)
go

CREATE TABLE [View]
( 
	[View_ID]            tinyint  NOT NULL ,
	[View_date]          datetime  NOT NULL ,
	[Video_ID]           tinyint  NOT NULL ,
	[User_ID]            tinyint  NOT NULL ,
	 PRIMARY KEY  CLUSTERED ([View_ID] ASC),
	 FOREIGN KEY ([Video_ID]) REFERENCES [Video]([Video_ID])
		ON DELETE CASCADE
		ON UPDATE CASCADE,
 FOREIGN KEY ([User_ID]) REFERENCES [User]([User_ID])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
)
go

CREATE TABLE [Videofile]
( 
	[Videofile_length]   time  NULL ,
	[Videofile_size]     int  NOT NULL ,
	[Videofile_resolution] nchar(10)  NOT NULL ,
	[Videofile_codec]    nchar(10)  NOT NULL ,
	[Videofile_aspectratio] nchar(5)  NOT NULL ,
	[Videofile_features] nchar(10)  NULL ,
	[Videofile_format]   nchar(10) NOT NULL ,
	[Video_ID]           tinyint  NOT NULL ,
	 PRIMARY KEY  CLUSTERED ([Video_ID] ASC),
	 FOREIGN KEY ([Video_ID]) REFERENCES [Video]([Video_ID])
		ON DELETE CASCADE
		ON UPDATE CASCADE
)
go

CREATE TABLE [Playlist]
( 
	[Playlist_ID]        tinyint  NOT NULL ,
	[Playlist_title]     nchar(100)  NOT NULL ,
	[Number_of_videos]   tinyint  NOT NULL ,
	[Privacy_ID]         tinyint   NOT NULL DEFAULT 0,
	 PRIMARY KEY  CLUSTERED ([Playlist_ID] ASC),
	 FOREIGN KEY ([Privacy_ID]) REFERENCES [Privacy]([Privacy_ID])
		ON DELETE SET DEFAULT
		ON UPDATE NO ACTION
)
go

CREATE TABLE [Video_Playlist]
( 
	[Video_ID]           tinyint  NOT NULL ,
	[Playlist_ID]        tinyint  NOT NULL ,
	 PRIMARY KEY  CLUSTERED ([Video_ID] ASC,[Playlist_ID] ASC),
	 FOREIGN KEY ([Video_ID]) REFERENCES [Video]([Video_ID])
		ON DELETE CASCADE
		ON UPDATE NO ACTION,
 FOREIGN KEY ([Playlist_ID]) REFERENCES [Playlist]([Playlist_ID])
		ON DELETE CASCADE
		ON UPDATE CASCADE
)
go

CREATE TABLE [User_Playlist]
( 
	[User_ID]            tinyint  NOT NULL ,
	[Playlist_ID]        tinyint  NOT NULL ,
	 PRIMARY KEY  CLUSTERED ([User_ID] ASC,[Playlist_ID] ASC),
	 FOREIGN KEY ([User_ID]) REFERENCES [User]([User_ID])
		ON DELETE CASCADE
		ON UPDATE NO ACTION,
 FOREIGN KEY ([Playlist_ID]) REFERENCES [Playlist]([Playlist_ID])
		ON DELETE CASCADE
		ON UPDATE CASCADE
)
go

CREATE TABLE [Subscribe]
( 
	[Subscribe_date]     datetime  NOT NULL ,
	[Subscriber_ID]      tinyint  NOT NULL ,
	[User_ID_subscriber] tinyint  NOT NULL ,
	[User_ID_channel]    tinyint  NOT NULL ,
	 PRIMARY KEY  CLUSTERED ([Subscriber_ID] ASC),
	 FOREIGN KEY ([User_ID_subscriber]) REFERENCES [User]([User_ID])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION,
 FOREIGN KEY ([User_ID_channel]) REFERENCES [User]([User_ID])
		ON DELETE CASCADE
		ON UPDATE NO ACTION
)
go

CREATE TABLE [Like]
( 
	[Like_date]          datetime  NOT NULL ,
	[Like_ID]            tinyint  NOT NULL ,
	[User_ID]            tinyint  NOT NULL ,
	[Video_ID]           tinyint  NOT NULL ,
	 PRIMARY KEY  CLUSTERED ([Like_ID] ASC),
	 FOREIGN KEY ([User_ID]) REFERENCES [User]([User_ID])
		ON DELETE NO ACTION
		ON UPDATE CASCADE,
 FOREIGN KEY ([Video_ID]) REFERENCES [Video]([Video_ID])
		ON DELETE CASCADE
		ON UPDATE NO ACTION
)
go

CREATE TABLE [Dislike]
( 
	[Dislike_date]       datetime  NOT NULL ,
	[Disike_ID]          tinyint  NOT NULL ,
	[Video_ID]           tinyint  NOT NULL ,
	[User_ID]            tinyint  NOT NULL ,
	 PRIMARY KEY  CLUSTERED ([Disike_ID] ASC),
	 FOREIGN KEY ([User_ID]) REFERENCES [User]([User_ID])
		ON DELETE NO ACTION
		ON UPDATE CASCADE,
 FOREIGN KEY ([Video_ID]) REFERENCES [Video]([Video_ID])
		ON DELETE CASCADE
		ON UPDATE NO ACTION
)
go

CREATE TABLE [Comment]
( 
	[Comment_ID]         tinyint  NOT NULL ,
	[Comment_text]       nchar(255)  NULL ,
	[Comment_date]       datetime  NOT NULL ,
	[User_ID]            tinyint  NOT NULL ,
	[Video_ID]           tinyint  NOT NULL ,
	 PRIMARY KEY  CLUSTERED ([Comment_ID] ASC),
	 FOREIGN KEY ([User_ID]) REFERENCES [User]([User_ID])
		ON DELETE NO ACTION
		ON UPDATE CASCADE,
 FOREIGN KEY ([Video_ID]) REFERENCES [Video]([Video_ID])
		ON DELETE CASCADE
		ON UPDATE NO ACTION
)