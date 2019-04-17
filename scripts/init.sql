\connect auth

CREATE TABLE usuarios (
    id SERIAL PRIMARY KEY NOT NULL,
    login VARCHAR(100) NOT NULL,
    password VARCHAR(250) NOT NULL
);

CREATE TABLE prestadores (
	id SERIAL PRIMARY KEY NOT NULL,
	nome VARCHAR(100) NOT NULL,
	latitude VARCHAR(100) NOT NULL,
	longitude VARCHAR(100) NOT NULL,
	telefone VARCHAR(15) NOT NULL,
	horario VARCHAR(100) NOT NULL
);

CREATE ROLE docker LOGIN PASSWORD 'docker'

ALTER TABLE "usuarios" OWNER TO docker;

Insert into usuarios(login,password) values( 'admin','AOfjLxMEZ9oVUB59+u4NVgx3t/WOTv1qa6zLdsic9QALuvKlE6tRoj/nZ3Q+7Ux0uA==');