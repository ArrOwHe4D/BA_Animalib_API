USE AnimalibDB;

INSERT INTO Species (Id, Name, Type, AnimalCount, Image) 
VALUES (1, 'Anthropoidea (Affen)', 'Sub-Spezies', 260, (SELECT BulkColumn FROM OPENROWSET(BULK N'C:\images\species_anthropoidea.png', SINGLE_BLOB) as Image));

INSERT INTO Species (Id, Name, Type, AnimalCount, Image) 
VALUES (2, 'Felidae (Katzen)', 'Sub-Spezies', 41, (SELECT BulkColumn FROM OPENROWSET(BULK N'C:\images\species_felidae.jpg', SINGLE_BLOB) as Image));

INSERT INTO Species (Id, Name, Type, AnimalCount, Image) 
VALUES (3, 'Accipitridae (Greifvögel)', 'Sub-Spezies', 240, (SELECT BulkColumn FROM OPENROWSET(BULK N'C:\images\species_accipitridae.jpg', SINGLE_BLOB) as Image));

INSERT INTO Species (Id, Name, Type, AnimalCount, Image) 
VALUES (4, 'Equidae (Pferde)', 'Sub-Spezies', 7, (SELECT BulkColumn FROM OPENROWSET(BULK N'C:\images\species_equidae.jpg', SINGLE_BLOB) as Image));

INSERT INTO Species (Id, Name, Type, AnimalCount, Image) 
VALUES (5, 'Ursidae (Bären)', 'Sub-Spezies', 8, (SELECT BulkColumn FROM OPENROWSET(BULK N'C:\images\species_ursidae.jpg', SINGLE_BLOB) as Image));

INSERT INTO Species (Id, Name, Type, AnimalCount, Image) 
VALUES (6, 'Perissodactyla (Unpaarhufer)', 'Spezies', 17, (SELECT BulkColumn FROM OPENROWSET(BULK N'C:\images\species_perissodactyla.jpg', SINGLE_BLOB) as Image));