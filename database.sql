-- SQLite setup script.
-- The app also creates this table automatically on startup if it does not exist.

CREATE TABLE IF NOT EXISTS Cars
(
    Id      INTEGER NOT NULL CONSTRAINT PK_Cars PRIMARY KEY AUTOINCREMENT,
    Make    TEXT NOT NULL,
    Model   TEXT NOT NULL,
    Year    INTEGER NOT NULL CHECK (Year BETWEEN 1886 AND 2100),
    Price   NUMERIC NOT NULL CHECK (Price >= 0),
    Mileage INTEGER NOT NULL CHECK (Mileage >= 0),
    Color   TEXT NULL,
    Notes   TEXT NULL,
    AddedOn TEXT NOT NULL DEFAULT (CURRENT_TIMESTAMP)
);
