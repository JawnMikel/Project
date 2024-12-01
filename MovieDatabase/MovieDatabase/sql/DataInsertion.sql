-- Insert statements for all possible genres
INSERT INTO genre (GenreName) 
VALUES 
    ('ACTION'),
    ('COMEDY'),
    ('MYSTERY'),
    ('HORROR'),
    ('SCI_FI'),
    ('ROMANCE'),
    ('THRILLER'),
    ('DRAMA'),
    ('MUSICAL'),
    ('WAR'),
    ('SUPERHERO'),
    ('ANIMATION'),
    ('DOCUMENTARY'),
    ('CRIME'),
    ('FANTASY');

-- Insert statement for the movies
INSERT INTO movie (Title, ReleaseDate, Duration, Synopsis, ImageLink)
VALUES 
    ('Harry Potter and the Deathly Hallows: Part 2', '2011-07-15', 130, 'As the battle between the forces of good and evil in the wizarding world escalates, Harry Potter draws ever closer to his final confrontation with Voldemort.', 'https://m.media-amazon.com/images/M/MV5BOTA1Mzc2N2ItZWRiNS00MjQzLTlmZDQtMjU0NmY1YWRkMGQ4XkEyXkFqcGc@._V1_.jpg'),
    ('The Lord of the Rings: The Two Towers', '2002-12-18', 179, 'While Frodo and Sam edge closer to Mordor with the help of the shifty Gollum, the divided fellowship makes a stand against Sauron''s new ally, Saruman, and his hordes of Isengard.', 'https://m.media-amazon.com/images/M/MV5BMGQxMDdiOWUtYjc1Ni00YzM1LWE2NjMtZTg3Y2JkMjEzMTJjXkEyXkFqcGc@._V1_.jpg'),
    ('Emilia Pérez', '2024-08-21', 132, 'Emilia Pérez follows four remarkable women in Mexico, each pursuing their own happiness. Cartel leader Emilia enlists Rita, an unappreciated lawyer, to help fake her death so that she can finally live authentically as her true self.', 'https://m.media-amazon.com/images/M/MV5BMGM0OGNhMzktZGFlNC00NDRmLWJmOTgtYmQ0N2JlZGJhMzQyXkEyXkFqcGc@._V1_QL75_UY281_CR9,0,190,281_.jpg'),
    ('Women of the Hour', '2024-10-18', 95, 'Sheryl Bradshaw, a single woman looking for a suitor on a hit 1970s TV show, chooses charming bachelor Rodney Alcala, unaware that, behind the man''s gentle facade, he hides a deadly secret.', 'https://m.media-amazon.com/images/M/MV5BYzliNzRjNDMtYTFmOS00NDQxLWJlOWMtZTViNjcyMzc0NzQwXkEyXkFqcGc@._V1_QL75_UX190_CR0,0,190,281_.jpg'),
    ('The Lost Children', '2024-11-24', 96, 'Four Indigenous children stranded in Colombian Amazon after plane crash. Guided by ancestral knowledge, they survive while awaiting rescue operation amid the jungle''s challenges.', 'https://m.media-amazon.com/images/M/MV5BZjcxZjFhMWItN2Y2MC00MmZhLWExNzEtOTBiNmYyODgyYWRkXkEyXkFqcGc@._V1_QL75_UY281_CR4,0,190,281_.jpg'),
    ('Return of the King: The Fall and Rise of Elvis Presley', '2024-11-13', 90, 'He had one chance to show the world he was still the King of Rock ''n'' Roll. Discover the story behind Elvis Presley''s triumphant ''68 comeback special.', 'https://m.media-amazon.com/images/M/MV5BNjRiNWU0MjYtYzk0OS00ZTExLTkyZGYtZDUxNDM4ZjJjNmQ4XkEyXkFqcGc@._V1_QL75_UX190_CR0,2,190,281_.jpg'),
    ('Inside Job', '2010-10-08', 109, 'Takes a closer look at what brought about the 2008 financial meltdown.', 'https://m.media-amazon.com/images/M/MV5BMTQ3MjkyODA2Nl5BMl5BanBnXkFtZTcwNzQxMTU4Mw@@._V1_QL75_UX190_CR0,0,190,281_.jpg'),
    ('Deadpool & Wolverine', '2024-07-26', 128, 'Deadpool is offered a place in the Marvel Cinematic Universe by the Time Variance Authority, but instead recruits a variant of Wolverine to save his universe from extinction.', 'https://m.media-amazon.com/images/M/MV5BZTk5ODY0MmQtMzA3Ni00NGY1LThiYzItZThiNjFiNDM4MTM3XkEyXkFqcGc@._V1_QL75_UX190_CR0,0,190,281_.jpg'),
    ('Spider-Man', '2002-05-03', 121, 'After being bitten by a genetically-modified spider, a shy teenager gains spider-like abilities that he uses to fight injustice as a masked superhero and face a vengeful enemy.', 'https://upload.wikimedia.org/wikipedia/en/thumb/6/6c/Spider-Man_(2002_film)_poster.jpg/220px-Spider-Man_(2002_film)_poster.jpg'),
    ('Blitz', '2024-11-01', 120, 'The stories of a group of Londoners during the German bombing campaign of the British capital during World War II.', 'https://m.media-amazon.com/images/M/MV5BMGI5ZjBkNDktOGMyMC00ZmYzLThmYjctYmViMmVkNDY3ZjExXkEyXkFqcGc@._V1_QL75_UX190_CR0,2,190,281_.jpg'),
    ('Saving Private Ryan', '1998-07-24', 169, 'Following the Normandy Landings, a group of U.S. soldiers go behind enemy lines to retrieve a paratrooper whose brothers have been killed in action.', 'https://m.media-amazon.com/images/M/MV5BZGZhZGQ1ZWUtZTZjYS00MDJhLWFkYjctN2ZlYjE5NWYwZDM2XkEyXkFqcGc@._V1_QL75_UY281_CR1,0,190,281_.jpg'),
    ('1917', '2019-12-25', 119, 'As an infantry battalion assembles to wage war deep in enemy territory, two soldiers are assigned to race against time and deliver a message that will stop 1,600 men from walking straight into a deadly trap.', 'https://m.media-amazon.com/images/M/MV5BYzkxZjg2NDQtMGVjMy00NWZkLTk0ZDEtZWE3NDYwYjAyMTg1XkEyXkFqcGc@._V1_QL75_UX190_CR0,10,190,281_.jpg'),
    ('The Greatest Showman', '2017-12-20', 105, 'Celebrates the birth of show business and tells of a visionary who rose from nothing to create a spectacle that became a worldwide sensation.', 'https://m.media-amazon.com/images/M/MV5BMjI1NDYzNzY2Ml5BMl5BanBnXkFtZTgwODQwODczNTM@._V1_QL75_UY281_CR1,0,190,281_.jpg'),
    ('Mamma Mia!', '2008-07-18', 108, 'Donna, an independent hotelier, is preparing for her daughter''s wedding with the help of two old friends. Meanwhile Sophie, the spirited bride, has a plan. She invites three men from her mother''s past in hope of meeting her real father.', 'https://m.media-amazon.com/images/M/MV5BMTA2MDU0MjM0MzReQTJeQWpwZ15BbWU3MDYwNzgwNzE@._V1_QL75_UX190_CR0,0,190,281_.jpg'),
    ('Pitch Perfect', '2012-10-05', 112, 'Beca, a freshman at Barden University, is cajoled into joining The Bellas, her school''s all-girls singing group. Injecting some much needed energy into their repertoire, The Bellas take on their male rivals in a campus competition.', 'https://i.ebayimg.com/images/g/xiwAAOSw6EVfiAw5/s-l1200.jpg'),
    ('The Substance', '2024-09-20', 141, 'A fading celebrity takes a black-market drug: a cell-replicating substance that temporarily creates a younger, better version of herself.', 'https://m.media-amazon.com/images/M/MV5BZDQ1NGE5MGMtYzdlZC00ODExLWJlMDMtNWU4NjA5OWYwMDEwXkEyXkFqcGc@._V1_QL75_UY281_CR1,0,190,281_.jpg'),
    ('Saturday Night', '2024-09-27', 109, 'At 11:30pm on October 11th, 1975, a ferocious troupe of young comedians and writers changed television forever. Find out what happened behind the scenes in the 90 minutes leading up to the first broadcast of Saturday Night Live (1975).', 'https://m.media-amazon.com/images/M/MV5BNWI0N2VlMTAtZGFhYS00YzdhLWEzM2EtMWUwMzBkYWQ5NTMwXkEyXkFqcGc@._V1_QL75_UX190_CR0,2,190,281_.jpg'),
    ('The Great Gatsby', '2013-05-10', 143, 'A writer and wall street trader, Nick Carraway, finds himself drawn to the past and lifestyle of his mysterious millionaire neighbor, Jay Gatsby, amid the riotous parties of the Jazz Age.', 'https://static.wikia.nocookie.net/cinemorgue/images/1/1e/Cvr9781451689433_9781451689433_hr.jpg'),
    ('Star Wars: Episode II - Attack of the Clones', '2002-05-12', 142, 'Ten years after initially meeting, Anakin Skywalker shares a forbidden romance with Padmé Amidala, while Obi-Wan Kenobi discovers a secret clone army crafted for the Jedi.', 'https://upload.wikimedia.org/wikipedia/en/3/32/Star_Wars_-_Episode_II_Attack_of_the_Clones_(movie_poster).jpg'),
    ('Avengers: Endgame', '2019-04-26', 181, 'After the devastating events of Avengers: Infinity War (2018), the universe is in ruins. With the help of remaining allies, the Avengers assemble once more in order to reverse Thanos'' actions and restore balance to the universe.', 'https://m.media-amazon.com/images/M/MV5BMTc5MDE2ODcwNV5BMl5BanBnXkFtZTgwMzI2NzQ2NzM@._V1_QL75_UX190_CR0,0,190,281_.jpg')
    ('The Hunger Games', '2012-03-12', 142, 'Katniss Everdeen voluntarily takes her younger sister''s place in the Hunger Games: a televised competition in which two teenagers from each of the twelve Districts of Panem are chosen at random to fight to the death.', 'https://lionsgate.brightspotcdn.com/38/0e/775e592e43be939f63c5f7e528a3/hungergames-movie-bg01-portrait1.jpg'),
    ('Titanic', '1997-11-18', 194, 'A seventeen-year-old aristocrat falls in love with a kind but poor artist aboard the luxurious, ill-fated R.M.S. Titanic.', 'https://miro.medium.com/v2/resize:fit:1200/0*5MFFtR8MBLOv1q_Z.jpg'),
    ('Inception', '2010-07-13', 148, 'A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O., but his tragic past may doom the project and his team to disaster.', 'https://i.ebayimg.com/images/g/B8oAAOSw2fdg5A-h/s-l1200.jpg'),
    ('Despicable Me', '2010-06-27', 95, 'Gru, a criminal mastermind, adopts three orphans as pawns to carry out the biggest heist in history. His life takes an unexpected turn when the little girls see the evildoer as their potential father.', 'https://www.coverwhiz.com/uploads/movies/despicable-me.jpg'),
    ('Spirited Away', '2001-07-20', 124, 'During her family''s move to the suburbs, a sullen 10-year-old girl wanders into a world ruled by gods, witches and spirits, and where humans are changed into beasts.', 'https://m.media-amazon.com/images/I/61ON14PVzoL._AC_UF894,1000_QL80_.jpg'),
    ('The Green Mile', '1999-12-08', 189, 'Paul Edgecomb, the head guard of a prison, meets an inmate, John Coffey, a black man who is accused of murdering two girls. His life changes drastically when he discovers that John has a special gift.', 'https://resizing.flixster.com/-XZAfHZM39UwaGJIFWKAE8fS0ak=/v3/t/assets/p24429_p_v12_bf.jpg'),
    ('Catch Me If You Can', '2002-12-16', 141, 'Barely 17 yet, Frank is a skilled forger who has passed as a doctor, lawyer and pilot. FBI agent Carl becomes obsessed with tracking down the con man, who only revels in the pursuit.', 'https://m.media-amazon.com/images/I/61rkxjG4uiL._AC_UF1000,1000_QL80_.jpg'),
    ('Interstellar', '2014-10-26', 169, 'When Earth becomes uninhabitable in the future, a farmer and ex-NASA pilot, Joseph Cooper, is tasked to pilot a spacecraft, along with a team of researchers, to find a new planet for humans.', 'https://resizing.flixster.com/-XZAfHZM39UwaGJIFWKAE8fS0ak=/v3/t/assets/p10543523_p_v8_as.jpg'),
    ('It', '2017-09-08', 135, 'In the summer of 1989, a group of bullied kids band together to destroy a shape-shifting monster, which disguises itself as a clown and preys on the children of Derry, their small Maine town.', 'https://upload.wikimedia.org/wikipedia/en/5/5a/It_(2017)_poster.jpg'),
    ('The Dark Knight', '2008-07-18', 152, 'When a menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman, James Gordon and Harvey Dent must work together to put an end to the madness.', 'https://i.etsystatic.com/23402008/r/il/024c7e/5568112558/il_fullxfull.5568112558_suid.jpg');

-- Insert statement for the actors
INSERT INTO actor (FirstName, LastName, ImageLink)
VALUES
    ('Ralph', 'Fiennes', 'https://m.media-amazon.com/images/M/MV5BMzc5MjE1NDgyN15BMl5BanBnXkFtZTcwNzg2ODgwNA@@._V1_QL75_UY207_CR9,0,140,207_.jpg'),
    ('Michael', 'Gambon', 'https://m.media-amazon.com/images/M/MV5BMTY3OTc4MTgyN15BMl5BanBnXkFtZTcwNTAxNjA3Mg@@._V1_QL75_UY207_CR7,0,140,207_.jpg'),
    ('Daniel', 'Radcliffe', 'https://m.media-amazon.com/images/M/MV5BYzVmYjIxMzgtZWU2Ny00MjAyLTk5ZWUtZDEyMTliYjczMmIxXkEyXkFqcGc@._V1_QL75_UX140_CR0,1,140,207_.jpg'),
    ('Rupert', 'Grint', 'https://m.media-amazon.com/images/M/MV5BODUwOTc5N2MtNTVmZi00MWE0LWE0Y2QtOTAyOTEzZDg1NGFiXkEyXkFqcGc@._V1_QL75_UX140_CR0,1,140,207_.jpg'),
    ('Emma', 'Watson', 'https://m.media-amazon.com/images/M/MV5BMTQ3ODE2NTMxMV5BMl5BanBnXkFtZTgwOTIzOTQzMjE@._V1_QL75_UY207_CR14,0,140,207_.jpg'),

    ('Bruce', 'Allpress', 'https://m.media-amazon.com/images/M/MV5BMjIzMTc1NTAyNV5BMl5BanBnXkFtZTcwMzkxODIwOA@@._V1_QL75_UY207_CR3,0,140,207_.jpg'),
    ('Sean', 'Astin', 'https://m.media-amazon.com/images/M/MV5BMjEzMjczOTQ1NF5BMl5BanBnXkFtZTcwMzI2NzYyMQ@@._V1_QL75_UY207_CR4,0,140,207_.jpg'),
    ('John', 'Bach', 'https://m.media-amazon.com/images/M/MV5BMTg1Mjg2MzM0OV5BMl5BanBnXkFtZTcwMDQ2NzMwOA@@._V1_QL75_UY207_CR4,0,140,207_.jpg'),

    ('Zoe', 'Saldana', 'https://m.media-amazon.com/images/M/MV5BMDFkMWQ5ZDItNGUzNS00YzI4LWIyOTctMDk0Mjc3MGQyZTYxXkEyXkFqcGc@._V1_QL75_UY207_CR22,0,140,207_.jpg'),
    ('Karla', 'Sofía Gascón', 'https://m.media-amazon.com/images/M/MV5BNzAzY2FiNTQtNzEyYS00YmZjLWJjM2MtNjQxZGQ3NGY3NGVlXkEyXkFqcGc@._V1_QL75_UY207_CR85,0,140,207_.jpg'),
    ('Selena', 'Gomez', 'https://m.media-amazon.com/images/M/MV5BMjAwNTE2MDMyMl5BMl5BanBnXkFtZTgwMjAyODM3MTI@._V1_QL75_UY207_CR8,0,140,207_.jpg'),

    ('Anna', 'Kendrick', 'https://m.media-amazon.com/images/M/MV5BMjIzOTA0OTQyN15BMl5BanBnXkFtZTcwMjE1OTIwMw@@._V1_QL75_UY207_CR3,0,140,207_.jpg'),
    ('Daniel', 'Zovatto', 'https://m.media-amazon.com/images/M/MV5BYTVmYjVkZWItNGVkMC00ZjM5LTg5ZmMtN2Y0OGFjZjg1ZTMwXkEyXkFqcGc@._V1_QL75_UX140_CR0,1,140,207_.jpg'),
    ('Tony', 'Hale', 'https://m.media-amazon.com/images/M/MV5BOWIxOTc1NDMtMTExNC00YjgwLTg1ZjctMDEzMzRjODdjNTRmXkEyXkFqcGc@._V1_QL75_UY207_CR36,0,140,207_.jpg'),
    ('Dan', 'Garza', 'https://m.media-amazon.com/images/M/MV5BY2IzNDMyMWMtMjgzOC00NjA2LWE1NTItMjczNWVkMDUxM2JlXkEyXkFqcGc@._V1_QL75_UX140_CR0,1,140,207_.jpg'),
    ('Stacy', 'Ines', 'https://m.media-amazon.com/images/M/MV5BYWNiMGRkMGMtN2EzMC00NDBiLWI1YTUtZTJhNjQ0NTM4ZGU0XkEyXkFqcGc@._V1_QL75_UX140_CR0,1,140,207_.jpg'),
    ('Eduardo', 'De Los Reyes', 'https://m.media-amazon.com/images/M/MV5BNWQ5ZGQyN2UtYjU0MC00YWY5LThhNWEtNDM5ZmRiOWZmMGZmXkEyXkFqcGc@._V1_QL75_UX140_CR0,1,140,207_.jpg'),

    ('Billy', 'Corgan', 'https://m.media-amazon.com/images/M/MV5BODY0NzgyMDI4MV5BMl5BanBnXkFtZTcwMDg3NzQ5NA@@._V1_QL75_UY207_CR6,0,140,207_.jpg'),
    ('Bob', 'Dylan', 'https://m.media-amazon.com/images/M/MV5BMTg5NTA3Mjc4Nl5BMl5BanBnXkFtZTcwMzU3ODM1Mw@@._V1_QL75_UX140_CR0,1,140,207_.jpg'),
    ('D.J.', 'Fontana', 'https://m.media-amazon.com/images/M/MV5BZmY0NWNjODAtMWUxNC00MGUyLTkzMjYtYTA2NmE0YzdlMzI4XkEyXkFqcGc@._V1_QL75_UY207_CR13,0,140,207_.jpg'),

    ('Matt', 'Damon', 'https://m.media-amazon.com/images/M/MV5BMTM0NzYzNDgxMl5BMl5BanBnXkFtZTcwMDg2MTMyMw@@._V1_QL75_UY207_CR7,0,140,207_.jpg'),
    ('Gylfi', 'Zoega', 'https://m.media-amazon.com/images/M/MV5BMTkwMzA1MjM0Nl5BMl5BanBnXkFtZTcwMDEzODc1Mw@@._V1_QL75_UY207_CR114,0,140,207_.jpg'),
    ('Andri', 'Snær Magnason', 'https://m.media-amazon.com/images/M/MV5BMjE0NzAwOTQwM15BMl5BanBnXkFtZTcwNDgyODc1Mw@@._V1_QL75_UY207_CR114,0,140,207_.jpg'),

    ('Ryan', 'Reynolds', 'https://m.media-amazon.com/images/M/MV5BMzRiNDhiMDQtYWZkMS00ZjU5LTg5NzUtOTc4NzE2Yzc0ZWUwXkEyXkFqcGc@._V1_QL75_UY207_CR0,0,140,207_.jpg'),
    ('Hugh', 'Jackman', 'https://m.media-amazon.com/images/M/MV5BNDExMzIzNjk3Nl5BMl5BanBnXkFtZTcwOTE4NDU5OA@@._V1_QL75_UX140_CR0,1,140,207_.jpg'),
    ('Emma', 'Corrin', 'https://m.media-amazon.com/images/M/MV5BNWRlNDA3YzUtYjhiZi00NTI5LThmMjUtYWRiMTg1ZmM2YTg3XkEyXkFqcGc@._V1_QL75_UX140_CR0,1,140,207_.jpg'),

    ('Tobey', 'Maguire', 'https://m.media-amazon.com/images/M/MV5BMTYwMTI5NTM2OF5BMl5BanBnXkFtZTcwODk3MDQ2Mg@@._V1_QL75_UY207_CR3,0,140,207_.jpg'),
    ('Willem', 'Dafoe', 'https://m.media-amazon.com/images/M/MV5BOTBjNWMzMDEtZGZiZi00ZTEyLWEzMDUtZGFiYTE0ODQwZWU5XkEyXkFqcGc@._V1_QL75_UY207_CR13,0,140,207_.jpg'),
    ('Kirsten', 'Dunst', 'https://m.media-amazon.com/images/M/MV5BMTQ3NzkwNzM1MV5BMl5BanBnXkFtZTgwMzE2MTQ3MjE@._V1_QL75_UY207_CR8,0,140,207_.jpg'),

    ('Saoirse', 'Ronan', 'https://m.media-amazon.com/images/M/MV5BMjExNTM5NDE4NV5BMl5BanBnXkFtZTcwNzczMzEzOQ@@._V1_QL75_UX140_CR0,2,140,207_.jpg'),
    ('Harris', 'Dickinson', 'https://m.media-amazon.com/images/M/MV5BOGU1MGQ5NDAtMTVlNy00MmY3LWIxYzQtMzhhY2VjNmU4ODhhXkEyXkFqcGc@._V1_QL75_UY207_CR41,0,140,207_.jpg'),
    ('Benjamin', 'Clémentine', 'https://m.media-amazon.com/images/M/MV5BZjE5NDFmZGYtNzJmZi00ZjFlLWIyYWMtZmVjOWZhZDc3M2UxXkEyXkFqcGc@._V1_CR745,8,549,823_QL75_UX140_CR0,1,140,207_.jpg'),

    ('Tom', 'Hanks', 'https://m.media-amazon.com/images/M/MV5BMTQ2MjMwNDA3Nl5BMl5BanBnXkFtZTcwMTA2NDY3NQ@@._V1_QL75_UY207_CR2,0,140,207_.jpg'),
    ('Vin', 'Diesel', 'https://m.media-amazon.com/images/M/MV5BMjExNzA4MDYxN15BMl5BanBnXkFtZTcwOTI1MDAxOQ@@._V1_QL75_UY207_CR5,0,140,207_.jpg'),
    ('Dean-Charles', 'Chapman', 'https://m.media-amazon.com/images/M/MV5BNzM2Mjc2NzAzMV5BMl5BanBnXkFtZTgwMjE0MzAwNTE@._V1_QL75_UY207_CR8,0,140,207_.jpg'),
    ('George', 'MacKay', 'https://m.media-amazon.com/images/M/MV5BMTQ4NjQ0NTEwOV5BMl5BanBnXkFtZTgwODQyMzIyMTI@._V1_QL75_UX140_CR0,1,140,207_.jpg'),
    ('Daniel', 'Mays', 'https://m.media-amazon.com/images/M/MV5BZGVmYTc5ZjgtMTQwZi00N2I4LWJiZjUtYjFjOWU1YTM0NDU1XkEyXkFqcGc@._V1_CR728,0,705,1058_QL75_UX140_CR0,1,140,207_.jpg'),

    ('Zendaya', 'Maree Stoermer Colema', 'https://m.media-amazon.com/images/M/MV5BZjM5N2U3MzQtZWU5My00YzE0LThmZTgtYjE1NDJjNmIzZmIxXkEyXkFqcGc@._V1_QL75_UY207_CR8,0,140,207_.jpg'),
    ('Michelle', 'Williams', 'https://m.media-amazon.com/images/M/MV5BMjExNjY5NDY0MV5BMl5BanBnXkFtZTgwNjQ1Mjg1MTI@._V1_QL75_UX140_CR0,2,140,207_.jpg'),

    ('Amanda', 'Seyfried', 'https://m.media-amazon.com/images/M/MV5BYTM0ZDcxNzctMzIwNi00NjliLTg5YzEtZDc4MDk0MDFiNzA4XkEyXkFqcGc@._V1_QL75_UY207_CR6,0,140,207_.jpg'),
    ('Stellan', 'Skarsgård', 'https://m.media-amazon.com/images/M/MV5BNTA5MmNiNzMtOTQ1MC00ZDc5LTg3NzItNTZjNWY1MjI2MGM3XkEyXkFqcGc@._V1_QL75_UY207_CR58,0,140,207_.jpg'),
    ('Pierce', 'Brosnan', 'https://m.media-amazon.com/images/M/MV5BMTMwMjMxNzM4OV5BMl5BanBnXkFtZTcwNDM5NzkxMw@@._V1_QL75_UY207_CR6,0,140,207_.jpg'),

    ('Skylar', 'Astin', 'https://m.media-amazon.com/images/M/MV5BOTRhYmE4MzAtY2I4ZS00YTMwLWI2MmUtYzkyODc1YjdiYjgyXkEyXkFqcGc@._V1_QL75_UX140_CR0,2,140,207_.jpg'),
    ('Ben', 'Platt', 'https://m.media-amazon.com/images/M/MV5BMjQ0NjUwMTYwNF5BMl5BanBnXkFtZTgwMDg4MTMwNTM@._V1_QL75_UY207_CR60,0,140,207_.jpg'),
    ('Brittany', 'Snow', 'https://m.media-amazon.com/images/M/MV5BMjdlZWI4ZDUtZTVmMS00ZjNiLTlhMzktNmQ4NGZjY2NhYWU0XkEyXkFqcGc@._V1_QL75_UX140_CR0,3,140,207_.jpg'),

    ('Demi', 'Moore', 'https://m.media-amazon.com/images/M/MV5BMTc2Mjc1MDE4MV5BMl5BanBnXkFtZTcwNzAyNDczNA@@._V1_QL75_UY207_CR6,0,140,207_.jpg'),
    ('Margaret', 'Qualley', 'https://m.media-amazon.com/images/M/MV5BOTE1YWZlMzgtYTMxOS00YWEwLWIzZTItYjI4ODM0ODZmODdmXkEyXkFqcGc@._V1_QL75_UY207_CR51,0,140,207_.jpg'),
    ('Dennis', 'Quaid', 'https://m.media-amazon.com/images/M/MV5BMTU4ODk3NTcyMl5BMl5BanBnXkFtZTcwOTIwMTQxMw@@._V1_QL75_UY207_CR4,0,140,207_.jpg'),

    ('Gabriel', 'LaBelle', 'https://m.media-amazon.com/images/M/MV5BYmZjZmZmY2QtNzJmYi00NGFhLWJhZDQtZTJlYjY2NmY5MGIxXkEyXkFqcGc@._V1_QL75_UY207_CR13,0,140,207_.jpg'),
    ('Rachel', 'Sennott', 'https://m.media-amazon.com/images/M/MV5BZjRmZTYzODYtNmJkMi00YWRmLWI3ZDAtODg1OGViZjJlYWU1XkEyXkFqcGc@._V1_QL75_UY207_CR86,0,140,207_.jpg'),
    ('Cory', 'Michael Smith', 'https://m.media-amazon.com/images/M/MV5BMjM2NzY4NzgzOF5BMl5BanBnXkFtZTgwNDU2NzAzMDI@._V1_QL75_UY207_CR5,0,140,207_.jpg'),

    ('Leonardo', 'DiCaprio', 'https://m.media-amazon.com/images/M/MV5BMjI0MTg3MzI0M15BMl5BanBnXkFtZTcwMzQyODU2Mw@@._V1_QL75_UY207_CR7,0,140,207_.jpg'),
    ('Lisa', 'Adam', 'https://m.media-amazon.com/images/M/MV5BZTA5M2I4ZDItMmQyNC00ZDVhLWIyMzgtZTZmMjhjZjM3ZTAxXkEyXkFqcGc@._V1_QL75_UY207_CR13,0,140,207_.jpg'),
    ('Amitabh', 'Bachchan', 'https://m.media-amazon.com/images/M/MV5BNTk1OTUxMzIzMV5BMl5BanBnXkFtZTcwMzMxMjI0Nw@@._V1_QL75_UY207_CR6,0,140,207_.jpg'),

    ('Ewan', 'McGregor', 'https://m.media-amazon.com/images/M/MV5BMTg1MjQ0MDg0Nl5BMl5BanBnXkFtZTcwNjYyNjI5Mg@@._V1_QL75_UX140_CR0,0,140,207_.jpg'),
    ('Natalie', 'Portman', 'https://m.media-amazon.com/images/M/MV5BNjk1M2RmODAtMjE0Ny00N2U0LWIwNWYtZTAxMDFiMzk1MjU5XkEyXkFqcGc@._V1_QL75_UX140_CR0,1,140,207_.jpg'),
    ('Hayden', 'Christensen', 'https://m.media-amazon.com/images/M/MV5BNDI3ZGEzMWUtMzgzMC00ZDIxLTgzYzEtZTM5YjczMTdkNmQzXkEyXkFqcGc@._V1_QL75_UY207_CR14,0,140,207_.jpg'),

    ('Robert', 'Downey Jr.', 'https://m.media-amazon.com/images/M/MV5BNzg1MTUyNDYxOF5BMl5BanBnXkFtZTgwNTQ4MTE2MjE@._V1_QL75_UX140_CR0,2,140,207_.jpg'),
    ('Chris', 'Evans', 'https://m.media-amazon.com/images/M/MV5BNzQ0YWM1ODEtZDFkYy00MGJhLTkwZDUtMzVkZjljODU3ZTRmXkEyXkFqcGc@._V1_QL75_UX140_CR0,1,140,207_.jpg'),
    ('Mark', 'Ruffalo', 'https://m.media-amazon.com/images/M/MV5BM2JiYzA0ZGItNmFhYy00MjIyLWEwN2QtMzRmNDUyNjNiZjBiXkEyXkFqcGc@._V1_QL75_UX140_CR0,1,140,207_.jpg'),

    ('Jennifer', 'Lawrence', 'https://m.media-amazon.com/images/M/MV5BOTU3NDE5MDQ4MV5BMl5BanBnXkFtZTgwMzE5ODQ3MDI@._V1_QL75_UX140_CR0,8,140,207_.jpg'),
    ('Stanley', 'Tucci', 'https://m.media-amazon.com/images/M/MV5BMTU1MzE4MjAzMV5BMl5BanBnXkFtZTcwMjA2MTMyMw@@._V1_QL75_UY207_CR6,0,140,207_.jpg'),
    ('Wes', 'Bentley', 'https://m.media-amazon.com/images/M/MV5BOTgyOTY5OTA5OF5BMl5BanBnXkFtZTcwNzM1MjM1Nw@@._V1_QL75_UX140_CR0,1,140,207_.jpg'),

    ('Kate', 'Winslet', 'https://m.media-amazon.com/images/M/MV5BODgzMzM2NTE0Ml5BMl5BanBnXkFtZTcwMTcyMTkyOQ@@._V1_QL75_UX140_CR0,4,140,207_.jpg'),
    ('Billy', 'Zane', 'https://m.media-amazon.com/images/M/MV5BMTI5NzA2NTE0NF5BMl5BanBnXkFtZTcwNzAxMTUxMw@@._V1_QL75_UY207_CR10,0,140,207_.jpg'),
    ('Kathy', 'Bates', 'https://m.media-amazon.com/images/M/MV5BNjg5YWM0YzItM2Q5MC00OWViLWI2NWUtZWQwNTk0NTA4ZGNjXkEyXkFqcGc@._V1_QL75_UY207_CR8,0,140,207_.jpg'),

    ('Joseph', 'Gordon-Levitt', 'https://m.media-amazon.com/images/M/MV5BMTY3NTk0NDI3Ml5BMl5BanBnXkFtZTgwNDA3NjY0MjE@._V1_QL75_UY207_CR2,0,140,207_.jpg'),
    ('Elliot', 'Page', 'https://m.media-amazon.com/images/M/MV5BZmM3ZjE2M2QtYzljOC00ZTI4LWFhNTItOWVhNTkzM2JhOTE3XkEyXkFqcGc@._V1_QL75_UY207_CR9,0,140,207_.jpg'),
    ('Cillian', 'Murphy', 'https://m.media-amazon.com/images/M/MV5BNWJjYjMzMTQtY2I2NS00YjJlLTg4YzAtNDBlZWQzNzVhMDkxXkEyXkFqcGc@._V1_QL75_UX140_CR0,1,140,207_.jpg'),
    ('Steve', 'Carell', 'https://m.media-amazon.com/images/M/MV5BMjMyOTM2OTk1Ml5BMl5BanBnXkFtZTgwMTI3MzkyNjM@._V1_QL75_UX140_CR0,1,140,207_.jpg'),
    ('Jason', 'Segel', 'https://m.media-amazon.com/images/M/MV5BMTUwNzcxNzM1Nl5BMl5BanBnXkFtZTgwNzA5NzU4MjE@._V1_QL75_UY207_CR8,0,140,207_.jpg'),
    ('Russell', 'Brand', 'https://m.media-amazon.com/images/M/MV5BMTUxMzA2Nzk0N15BMl5BanBnXkFtZTcwMDgwMTEwNQ@@._V1_QL75_UY207_CR3,0,140,207_.jpg'),

    ('Rumi', 'Hiiragi', 'https://m.media-amazon.com/images/M/MV5BOTE2ZTYxNjgtNGM0MC00ZmUxLTkwOGMtNTY4ZTFjNTg3MWE5XkEyXkFqcGc@._V1_QL75_UY207_CR6,0,140,207_.jpg'),
    ('Miyu', 'Irino', 'https://m.media-amazon.com/images/M/MV5BOTVmNDU2MjYtMjhmNS00NjQ0LWJkZGItZjdlYjZlN2YzYWRhXkEyXkFqcGc@._V1_QL75_UY207_CR11,0,140,207_.jpg'),
    ('Tatsuya', 'Gashûin', 'https://m.media-amazon.com/images/M/MV5BYTQ5ZjY5NmUtZjczZS00OWQxLWE4NjktZjU2MmZjMzlmNThlXkEyXkFqcGc@._V1_QL75_UY207_CR1,0,140,207_.jpg'),

    ('David', 'Morse', 'https://m.media-amazon.com/images/M/MV5BMTgwNjUzOTE1N15BMl5BanBnXkFtZTYwNTU4NDQ0._V1_QL75_UY207_CR1,0,140,207_.jpg'),
    ('Bonnie', 'Hunt', 'https://m.media-amazon.com/images/M/MV5BY2Q4ZDFkZjUtNzBlZC00ODgzLTkzMDUtNzQyNzQ0NDBkYTg4XkEyXkFqcGc@._V1_QL75_UX140_CR0,1,140,207_.jpg'),
    ('Michael', 'Clarke Duncan', 'https://m.media-amazon.com/images/M/MV5BMTI3NDY2ODk5OV5BMl5BanBnXkFtZTYwMjQ0NzE0._V1_QL75_UY207_CR18,0,140,207_.jpg'),

    ('Amy', 'Adams', 'https://m.media-amazon.com/images/M/MV5BMTg2NTk2MTgxMV5BMl5BanBnXkFtZTgwNjcxMjAzMTI@._V1_QL75_UX140_CR0,3,140,207_.jpg'),
    ('Christopher', 'Walken', 'https://m.media-amazon.com/images/M/MV5BMjA4ODUyNDQ2NV5BMl5BanBnXkFtZTYwODk2MTYz._V1_QL75_UY207_CR2,0,140,207_.jpg'),
    ('Martin', 'Sheen', 'https://m.media-amazon.com/images/M/MV5BOTM1MTA5MTY0MV5BMl5BanBnXkFtZTcwMTQ4OTUzMg@@._V1_QL75_UY207_CR5,0,140,207_.jpg'),

    ('Ellen', 'Burstyn', 'https://m.media-amazon.com/images/M/MV5BMTU4MjYxMDc3MF5BMl5BanBnXkFtZTYwNzU3MDIz._V1_QL75_UX140_CR0,1,140,207_.jpg'),
    ('Matthew', 'McConaughey', 'https://m.media-amazon.com/images/M/MV5BMTg0MDc3ODUwOV5BMl5BanBnXkFtZTcwMTk2NjY4Nw@@._V1_QL75_UX140_CR0,10,140,207_.jpg'),
    ('Mackenzie', 'Foy', 'https://m.media-amazon.com/images/M/MV5BZTczM2FhOTEtOTE4OS00OWM2LTgwMjktNGRlN2NkODI0M2YwXkEyXkFqcGc@._V1_QL75_UX140_CR0,1,140,207_.jpg'),

    ('Bill', 'Skarsgård', 'https://m.media-amazon.com/images/M/MV5BMmNhMDQ1YjktYTg1Ny00Mjg0LWFmZTgtMmE0OTkxYmQzYzVlXkEyXkFqcGc@._V1_QL75_UY207_CR79,0,140,207_.jpg'),
    ('Jaeden', 'Martell', 'https://m.media-amazon.com/images/M/MV5BNWRiYjk4MTItNWMzMC00ZjE1LWFlNDItNDI2MmI4MDZlZjlkXkEyXkFqcGc@._V1_QL75_UX140_CR0,1,140,207_.jpg'),
    ('Jeremy', 'Ray Taylor', 'https://m.media-amazon.com/images/M/MV5BZjM0NDdiZDQtOTJjMS00Njk1LTllM2ItODQzYWU4ZDVjZDViXkEyXkFqcGc@._V1_QL75_UX140_CR0,1,140,207_.jpg'),

    ('Christian', 'Bale', 'https://m.media-amazon.com/images/M/MV5BMTkxMzk4MjQ4MF5BMl5BanBnXkFtZTcwMzExODQxOA@@._V1_QL75_UX140_CR0,1,140,207_.jpg'),
    ('Heath', 'Ledger', 'https://m.media-amazon.com/images/M/MV5BMTI2NTY0NzA4MF5BMl5BanBnXkFtZTYwMjE1MDE0._V1_QL75_UX140_CR0,1,140,207_.jpg'),
    ('Aaron', 'Eckhart', 'https://m.media-amazon.com/images/M/MV5BMTc4MTAyNzMzNF5BMl5BanBnXkFtZTcwMzQ5MzQzMg@@._V1_QL75_UY207_CR4,0,140,207_.jpg');
