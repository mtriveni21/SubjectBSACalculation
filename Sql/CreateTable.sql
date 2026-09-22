-- Adding manual table over EF migrations.
-- Database: SubjectBSACalculation

CREATE TABLE Subjects (
    Id             INT IDENTITY(1,1) PRIMARY KEY,
    HeightCm       FLOAT         NOT NULL,
    WeightKg       FLOAT         NOT NULL,
    Gender         NVARCHAR(20)  NOT NULL,
    Age            INT           NOT NULL,
    BsaFormulaType INT           NOT NULL,   -- 1 = Du Bois, 2 = Mosteller
    BsaResult      FLOAT         NOT NULL,   -- BSA in m^2
    CreatedUtc     DATETIME2     NOT NULL DEFAULT SYSUTCDATETIME()
);
