ALTER TABLE menu
ADD COLUMN price INTEGER;

ALTER TABLE menu
ADD CONSTRAINT price_check CHECK (price > 0);