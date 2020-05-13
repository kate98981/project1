CREATE database myservice;

CREATE TABLE myservice.public.client
(
	id bigserial not null
		constraint clients_pk
			primary key,
	surname text not null,
	name text not null,
	middle_name text,
	phone text not null
);
INSERT INTO myservice.public.client(surname, name, middle_name, phone)
values ('Иванов', 'Иван', 'Иванович', '+79111111111'),
       ('Петров', 'Петр', 'Петрович', '+79222222222'),
       ('Петрова', 'Наталья', 'Алексеевна', '+79333333333'),
	   ('Сергеев', 'Сергей', 'Сергеевич', '+7944444444');

CREATE TABLE myservice.public.service
(
	id bigserial not null
		constraint service_pk
			primary key,
	name text not null,
	price text not null
);
INSERT INTO myservice.public.service(name, price)
values ('Настройка windows', '1500-5000'),
       ('Ремонт компьютера', '1000-8000'),
       ('Очистка клавиатуры ноутбука', '7000'),
       ('Сборка системного блока', '3000'),
       ('Замена деталей', '1000');

CREATE TABLE myservice.public.request
(
id bigserial not null
		constraint request_pk
			primary key,
	client_id int8 not null
		constraint client_fk
			references myservice.public.client
				on delete cascade,
	service_id int8 not null
		constraint service_fk
			references myservice.public.service
				on delete cascade
);
INSERT INTO myservice.public.request(client_id, service_id)
values (1, 1),
       (2, 4),
       (3, 5),
       (4, 2);
