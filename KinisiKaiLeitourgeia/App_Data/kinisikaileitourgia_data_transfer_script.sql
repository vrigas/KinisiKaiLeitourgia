
SELECT 'set IDENTITY_INSERT Insurances ON;';
SELECT 'INSERT INTO Insurances (Id, Name) VALUES (' + CAST(AsfID AS VARCHAR) + ', N''' + UPPER(AsfName) + ''');' 
FROM LexAsfalistikosForeas
SELECT 'set IDENTITY_INSERT Insurances OFF;';

SELECT 'set IDENTITY_INSERT DoctorSpecialties ON;'
SELECT 'INSERT INTO DoctorSpecialties (Id, Name) VALUES (' + CAST(EidID AS VARCHAR) + ', N''' + UPPER(EidName) + ''');' 
FROM LexEidikotitaIatrou
SELECT 'set IDENTITY_INSERT DoctorSpecialties OFF;';

SELECT 'set IDENTITY_INSERT TypeAppointments ON;'
SELECT 'INSERT INTO TypeAppointments (Id, Name) VALUES (' + CAST(EiRID AS VARCHAR) + ', N''' + UPPER(EiRName) + ''');' 
FROM LexEidosRantevou
SELECT 'set IDENTITY_INSERT TypeAppointments OFF;';

SELECT 'set IDENTITY_INSERT DoctorWorkplaces ON;'
SELECT 'INSERT INTO DoctorWorkplaces (Id, Name) VALUES (' + CAST(ErgID AS VARCHAR) + ', N''' + UPPER(ErgName) + ''');' 
FROM LexErgasiakosForeas
SELECT 'set IDENTITY_INSERT DoctorWorkplaces OFF;';

SELECT 'set IDENTITY_INSERT AppointmentPlaces ON;'
SELECT 'INSERT INTO AppointmentPlaces (Id, Name) VALUES (' + CAST(MeRID AS VARCHAR) + ', N''' + UPPER(MeRName) + ''');' 
FROM LexMerosRantevou
SELECT 'set IDENTITY_INSERT AppointmentPlaces OFF;';