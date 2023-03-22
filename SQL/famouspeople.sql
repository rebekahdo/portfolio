CREATE TABLE movie_stars (
  id INT PRIMARY KEY,
  name VARCHAR(255),
  birthdate DATE,
  nationality VARCHAR(255)
);

CREATE TABLE movies (
  id INT PRIMARY KEY,
  title VARCHAR(255),
  release_date DATE,
  director VARCHAR(255),
  actor_id INT,
  actress_id INT,
  supporting_id INT,
  FOREIGN KEY (actor_id) REFERENCES movie_stars(id),
  FOREIGN KEY (actress_id) REFERENCES movie_stars(id),
  FOREIGN KEY (supporting_id) REFERENCES movie_stars(id)
);

CREATE TABLE singers (
  id INT PRIMARY KEY,
  name VARCHAR(255),
  birthdate DATE,
  nationality VARCHAR(255)
);

CREATE TABLE songs (
  id INT PRIMARY KEY,
  title VARCHAR(255),
  release_date DATE,
  artist_id INT,
  composer_id INT,
  FOREIGN KEY (artist_id) REFERENCES singers(id),
  FOREIGN KEY (composer_id) REFERENCES singers(id)
);

CREATE TABLE authors (
  id INT PRIMARY KEY,
  name VARCHAR(255),
  birthdate DATE,
  nationality VARCHAR(255)
);

CREATE TABLE books (
  id INT PRIMARY KEY,
  title VARCHAR(255),
  release_date DATE,
  author_id INT,
  FOREIGN KEY (author_id) REFERENCES authors(id)
);

SELECT movies.title
FROM movies
JOIN movie_stars ON movies.actor_id = movie_stars.id
WHERE movie_stars.name = 'Tom Hanks';
