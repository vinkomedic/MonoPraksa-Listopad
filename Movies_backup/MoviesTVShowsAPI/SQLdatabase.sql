create table genres
(
<<<<<<< HEAD
	id UUID primary key default gen_random_uuid(),
	name varchar(50) not null
=======
    id uuid primary key default gen_random_uuid(),
    name varchar(50) not null
>>>>>>> ed6b70f (Changed folder name and update api)
);

create table movies
(
<<<<<<< HEAD
	id UUID primary key default gen_random_uuid(),
	title varchar(50) not null,
	year int not null,
	rating decimal(3,1),
	genreid UUID,
	
	constraint fk_movies_genres foreign key (genreid) references genres(id)
);



alter table movies 
add column durationMin INT;

insert into genres (name) values 
('Action'), 
('Sci-Fi'), 
('Comedy');

select * from genres;


insert into movies (title, year, rating, genreid, durationMin) values
('Gladiator', 2000, 9.5,(SELECT id FROM genres WHERE name = 'Action'), 155),
('Interstellar', 2014, 9.2, (SELECT id FROM genres WHERE name = 'Sci-Fi'), 169),
('Deadpool 2', 2018, 7.5, (SELECT id FROM genres WHERE name = 'Action'), 119),
('Ted', 2012, 7.8,(SELECT id FROM genres WHERE name = 'Comedy'), 120);

select * from movies;

select * from movies where rating >= 8;

select * from movies order by rating desc;

update movies set rating = 9.3 where title = 'Interstellar';

delete from movies where title = 'Ted';

insert into movies (title, year, rating, genreid, durationMin) values ('Ted', 2012, 7.8, 3, 120);

select movies.title, movies.year, movies.rating, genres.name as "Genre" from movies 
inner join genres on movies.genreid = genres.id;

select genres.name, count(movies.id) as "Number Of Movies" from genres left join movies
on genres.id = movies.genreid group by genres."name";

drop table genres CASCADE;
drop table movies CASCADE;




=======
    id uuid primary key default gen_random_uuid(),
    title varchar(50) not null,
    year int not null,
    rating decimal(3,1),
    genreid uuid,

    constraint fk_movies_genres
        foreign key (genreid)
        references genres(id)
);

alter table movies
add column durationmin int;

insert into genres (name)
values
('Action'),
('Sci-Fi'),
('Comedy');

insert into movies (title, year, rating, genreid, durationmin)
values
('Gladiator', 2000, 9.5, (select id from genres where name = 'Action'), 155),
('Interstellar', 2014, 9.2, (select id from genres where name = 'Sci-Fi'), 169),
('Deadpool 2', 2018, 7.5, (select id from genres where name = 'Action'), 119),
('Ted', 2012, 7.8, (select id from genres where name = 'Comedy'), 120);

-- Primjeri upita
select * from genres;
select * from movies;
select * from movies where rating >= 8;
select * from movies order by rating desc;

update movies
set rating = 9.3
where title = 'Interstellar';

select movies.title, movies.year, movies.rating, genres.name as "Genre"
from movies
inner join genres on movies.genreid = genres.id;

select genres.name, count(movies.id) as "Number Of Movies"
from genres
left join movies on genres.id = movies.genreid
group by genres.name;
>>>>>>> ed6b70f (Changed folder name and update api)
