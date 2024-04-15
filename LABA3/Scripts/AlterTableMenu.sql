ALTER TABLE menu
ADD COLUMN price SET DATA TYPE double precision;

ALTER TABLE menu
ADD CONSTRAINT price_check CHECK (price > 0);