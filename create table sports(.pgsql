create table sports(
    id serial PRIMARY KEY,
    name varchar(200),
    description varchar(1000)
);

create table judges(
    id serial PRIMARY KEY,
    name varchar(150),
    age INTEGER,
    raiting numeric(4),
    sport_id integer REFERENCES sports(id)
);

create table cretificates(
    id serial PRIMARY KEY,
    name varchar(200),
    location varchar(300),
    type integer
);

create table judge_certificates(
    id serial PRIMARY KEY,
    judge_id integer REFERENCES judges(id),
    cert_id integer REFERENCES cretificates(id)
);