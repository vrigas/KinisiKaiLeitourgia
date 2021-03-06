
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

SELECT 'set IDENTITY_INSERT Therapists ON;'
SELECT 'INSERT INTO AppointmentPlaces (Id, Name) VALUES (' + CAST(MeRID AS VARCHAR) + ', N''' + UPPER(MeRName) + ''');' 
FROM LexMerosRantevou
SELECT 'set IDENTITY_INSERT AppointmentPlaces OFF;';



SELECT 'set IDENTITY_INSERT People ON;'
SELECT 'INSERT INTO People (Id, Name, Surname, Telephone, Mobile, Email, Address, Info, Discriminator, LicenceNumber, AMKA) VALUES (
					  ' + CAST(TheID AS VARCHAR) + ', 
					  N''' + UPPER(TheOnoma) + ''',
					  N''' + UPPER(TheEponymo) + ''',
					  N''' + UPPER(TheThlefono) + ''',
					  N''' + UPPER(TheKinito) + ''',
					  N''' + UPPER(TheEmail) + ''',
					  N''' + UPPER(TheOdos + ' ' + TheArithmos + ', ' + ThePerioxi) + ''',
					  N''' + UPPER(TheSholia) + ''',
					  N''' + 'Therapist' + ''',
					  N''' + UPPER(TheArAdeias) + ''',
					  N''' + UPPER(TheAMKA) + '''
					  );' 
FROM Therapeftis
SELECT 'set IDENTITY_INSERT People OFF;';

SELECT 'set IDENTITY_INSERT People ON;'
SELECT 'INSERT INTO People (Id, Name, Surname, Telephone, Workphone, Mobile, Email, Address, Info, Discriminator, DoctorWorkplaceId, DoctorSpecialtyId) VALUES (
					  ' + CAST(IatID+10 AS VARCHAR) + ', 
					  N''' + UPPER(IatOnoma) + ''',
					  N''' + UPPER(IatEponymo) + ''',
					  N''' + UPPER(IatThlefono) + ''',
					  N''' + UPPER(isnull(IatThlefono2,'')) + ''',
					  N''' + UPPER(IatKinito) + ''',
					  N''' + UPPER(IatEmail) + ''',
					  N''' + UPPER(IatOdos + ' ' + IatArithmos + ', ' + IatPerioxi) + ''',
					  N''' + UPPER(IatSholia) + ''',
					  N''' + 'Doctor' + ''',
					  N''' + UPPER(cast(IatErgasForeas as varchar)) + ''',
					  N''' + UPPER(cast(IatEidikotita as varchar)) + '''
					  );' 
FROM Iatros
SELECT 'set IDENTITY_INSERT People OFF;';

SELECT 'set IDENTITY_INSERT People ON;'
SELECT 'INSERT INTO People (Id, Name, Surname, Telephone, Mobile, Email, Birthdate, Address, Info, Discriminator, CurrentDoctorId, ReferrerDoctorId, InsuranceId) VALUES (
					  ' + CAST(AstID+100 AS VARCHAR) + ', 
					  N''' + UPPER(AstOnoma) + ''',
					  N''' + UPPER(AstEponymo) + ''',
					  N''' + UPPER(AstThlefono) + ''',
					  N''' + UPPER(AstKinito) + ''',
					  N''' + UPPER(AstEmail) + ''',
					  N''' + cast(case when AstDateGenisis = '00010101' then '19000101' else AstDateGenisis end as varchar) + ''',
					  N''' + UPPER(AstOdos + ' ' + AstArithmos + ', ' + AstPerioxi) + ''',
					  N''' + UPPER(AstSholia) + ''',
					  N''' + 'Patient' + ''',
					  ' + case when AstTheraponIat is null then 'null' else 'N''' + cast(AstTheraponIat+10 as varchar) + '''' end + ',
					  ' + case when AstParapemIat is null then 'null' else 'N''' + cast(AstParapemIat+10 as varchar) + '''' end + ',
					  ' + case when AstAsfalForeas is null then 'null' else 'N''' + cast(AstAsfalForeas as varchar) + '''' end + '
					  );' 
FROM Asthenis
SELECT 'set IDENTITY_INSERT People OFF;';


SELECT 'set IDENTITY_INSERT Appointments ON;'
SELECT 'INSERT INTO Appointments (TaskID, Title, [Description], IsAllDay, [Start], [End], PatientId, TherapistId, Price, Balance, AppointmentPlaceId, TypeAppointmentId) VALUES (
					  ' + CAST(RanID AS VARCHAR) + ', 
					  N''' + UPPER(isnull(AstEponymo,'') + ' ' + isnull(AstOnoma,'') + ' - ' + TheEponymo) + ''',
					  N''' + UPPER(RanSholia) + ''',
					  ' + '0' + ',
					  N''' + convert(varchar,DATEDIFF(dd, 0,RanDate) + CONVERT(DATETIME,RanFrom),121) + ''',
					  N''' + convert(varchar,DATEDIFF(dd, 0,RanDate) + CONVERT(DATETIME,RanTo),121) + ''',
					  N''' + CAST(RanAstId + 100 AS VARCHAR) + ''',
					  N''' + CAST(RanTheId AS VARCHAR) + ''',
					  N''' + CAST(RanTimh AS VARCHAR) + ''',
					  N''' + CAST(RanTimh AS VARCHAR) + ''',
					  ' + case when RanMeRID is null then '2' else  cast(RanMeRID as varchar)  end + ',
					  ' + case when RanEiRID is null then '7' else  cast(RanEiRID as varchar)  end + '
					  );' 
FROM Rantevou join Asthenis on RanAstId = AstId
			 join Therapeftis on RanTheId = TheId
SELECT 'set IDENTITY_INSERT Appointments OFF;';


select * from rantevou where ran is null