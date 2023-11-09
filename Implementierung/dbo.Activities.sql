CREATE TABLE [dbo].[Aktivitäten]
(
	[Aktivitäts_Id] INT NOT NULL PRIMARY KEY,
	constraint [Nutzer_ID] Foreign Key (Benutzer_Id)
	References Benutzer(Benutzer_Id),
	[Eingabe] nvarchar(500),
	[Ausgabe] nvarchar(500),
	[Eingabe_Sprache] nvarchar(50),
	[Ausgabe_Sprache] nvarchar(50),
	[Zeitstempel] datetime 	


)
