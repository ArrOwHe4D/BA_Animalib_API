use AnimalibDB;

INSERT INTO Regions (Id, Name, Size, SpeciesCount, Image) 
VALUES (1, 'Afrika', 30221532, 250000, (SELECT BulkColumn FROM OPENROWSET(BULK N'C:\images\regions_africa.jpg', SINGLE_BLOB) as Image));

INSERT INTO Regions (Id, Name, Size, SpeciesCount, Image) 
VALUES (2, 'Nordamerika', 24930000, 120000, (SELECT BulkColumn FROM OPENROWSET(BULK N'C:\images\regions_northamerica.jpg', SINGLE_BLOB) as Image));

INSERT INTO Regions (Id, Name, Size, SpeciesCount, Image) 
VALUES (3, 'Europa', 10523000, 118000, (SELECT BulkColumn FROM OPENROWSET(BULK N'C:\images\regions_europe.jpg', SINGLE_BLOB) as Image));

INSERT INTO Regions (Id, Name, Size, SpeciesCount, Image) 
VALUES (4, 'Asien', 44614500, 376000, (SELECT BulkColumn FROM OPENROWSET(BULK N'C:\images\regions_asia.jpg', SINGLE_BLOB) as Image));

INSERT INTO Regions (Id, Name, Size, SpeciesCount, Image) 
VALUES (5, 'Südamerika', 17843000, 250000, (SELECT BulkColumn FROM OPENROWSET(BULK N'C:\images\regions_southamerica.jpg', SINGLE_BLOB) as Image));

INSERT INTO Regions (Id, Name, Size, SpeciesCount, Image) 
VALUES (6, 'Australien', 7688287, 270000, (SELECT BulkColumn FROM OPENROWSET(BULK N'C:\images\regions_australia.jpg', SINGLE_BLOB) as Image));

INSERT INTO Regions (Id, Name, Size, SpeciesCount, Image) 
VALUES (7, 'Antarktika', 13924000, 8700, (SELECT BulkColumn FROM OPENROWSET(BULK N'C:\images\regions_antarctica.jpg', SINGLE_BLOB) as Image));