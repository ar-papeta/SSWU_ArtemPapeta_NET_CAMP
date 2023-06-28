CREATE TABLE `Terminal`(
    `terminal_id` INT NOT NULL,
    `airport_id` INT NOT NULL,
    `name` TEXT NOT NULL
);
ALTER TABLE
    `Terminal` ADD PRIMARY KEY(`terminal_id`);
CREATE TABLE `Gate`(
    `gate_id` INT NOT NULL,
    `terminal_id` INT NOT NULL,
    `number` TEXT NOT NULL
);
ALTER TABLE
    `Gate` ADD PRIMARY KEY(`gate_id`);
CREATE TABLE `Runway`(
    `runway_id` INT NOT NULL,
    `airport_id` INT NOT NULL,
    `number` TEXT NOT NULL
);
ALTER TABLE
    `Runway` ADD PRIMARY KEY(`runway_id`);
CREATE TABLE `Baggage`(
    `baggage_id` INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `passenger_id` INT NOT NULL,
    `baggage_info_id` BIGINT NOT NULL
);
CREATE TABLE `Baggage_info`(
    `baggage_info_id` BIGINT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `weight` INT NOT NULL,
    `height` INT NOT NULL,
    `length` INT NOT NULL,
    `width` INT NOT NULL
);
CREATE TABLE `Passenger`(
    `passenger_id` INT NOT NULL,
    `flight_id` INT NOT NULL,
    `name` TEXT NOT NULL,
    `lastname` TEXT NOT NULL,
    `age` INT NOT NULL,
    `gender` ENUM('') NOT NULL
);
ALTER TABLE
    `Passenger` ADD PRIMARY KEY(`passenger_id`);
CREATE TABLE `Employee`(
    `employee_id` INT NOT NULL,
    `airport_id` INT NOT NULL,
    `name` TEXT NOT NULL,
    `lastname` TEXT NOT NULL,
    `position` TEXT NOT NULL
);
ALTER TABLE
    `Employee` ADD PRIMARY KEY(`employee_id`);
CREATE TABLE `Airline`(
    `airline_id` INT NOT NULL,
    `name` TEXT NOT NULL,
    `country` TEXT NOT NULL
);
ALTER TABLE
    `Airline` ADD PRIMARY KEY(`airline_id`);
CREATE TABLE `Airport`(
    `airport_id` INT NOT NULL,
    `IATA` TEXT NOT NULL,
    `name` TEXT NOT NULL,
    `city` TEXT NOT NULL,
    `country` TEXT NOT NULL
);
ALTER TABLE
    `Airport` ADD PRIMARY KEY(`airport_id`);
CREATE TABLE `Ticket`(
    `ticket_id` INT NOT NULL,
    `flight_id` INT NOT NULL,
    `passenger_id` INT NOT NULL,
    `seat_number` TEXT NOT NULL,
    `prior_type` ENUM('') NOT NULL
);
ALTER TABLE
    `Ticket` ADD PRIMARY KEY(`ticket_id`);
CREATE TABLE `Flight`(
    `flight_id` INT NOT NULL,
    `airline_id` INT NOT NULL,
    `arrival_airport_id` INT NOT NULL,
    `flight_number` TEXT NOT NULL,
    `departure_airport_id` INT NOT NULL,
    `departure_date_time` DATETIME NOT NULL,
    `arrival_date_time` DATETIME NOT NULL,
    `airplane_model` TEXT NOT NULL
);
ALTER TABLE
    `Flight` ADD PRIMARY KEY(`flight_id`);
ALTER TABLE
    `Baggage` ADD CONSTRAINT `baggage_baggage_info_id_foreign` FOREIGN KEY(`baggage_info_id`) REFERENCES `Baggage_info`(`baggage_info_id`);
ALTER TABLE
    `Flight` ADD CONSTRAINT `flight_departure_airport_id_foreign` FOREIGN KEY(`departure_airport_id`) REFERENCES `Airport`(`airport_id`);
ALTER TABLE
    `Terminal` ADD CONSTRAINT `terminal_airport_id_foreign` FOREIGN KEY(`airport_id`) REFERENCES `Airport`(`airport_id`);
ALTER TABLE
    `Flight` ADD CONSTRAINT `flight_arrival_airport_id_foreign` FOREIGN KEY(`arrival_airport_id`) REFERENCES `Airport`(`airport_id`);
ALTER TABLE
    `Passenger` ADD CONSTRAINT `passenger_flight_id_foreign` FOREIGN KEY(`flight_id`) REFERENCES `Flight`(`flight_id`);
ALTER TABLE
    `Gate` ADD CONSTRAINT `gate_terminal_id_foreign` FOREIGN KEY(`terminal_id`) REFERENCES `Terminal`(`terminal_id`);
ALTER TABLE
    `Employee` ADD CONSTRAINT `employee_airport_id_foreign` FOREIGN KEY(`airport_id`) REFERENCES `Airport`(`airport_id`);
ALTER TABLE
    `Baggage` ADD CONSTRAINT `baggage_passenger_id_foreign` FOREIGN KEY(`passenger_id`) REFERENCES `Passenger`(`passenger_id`);
ALTER TABLE
    `Flight` ADD CONSTRAINT `flight_airline_id_foreign` FOREIGN KEY(`airline_id`) REFERENCES `Airline`(`airline_id`);
ALTER TABLE
    `Runway` ADD CONSTRAINT `runway_airport_id_foreign` FOREIGN KEY(`airport_id`) REFERENCES `Airport`(`airport_id`);
ALTER TABLE
    `Ticket` ADD CONSTRAINT `ticket_flight_id_foreign` FOREIGN KEY(`flight_id`) REFERENCES `Flight`(`flight_id`);
ALTER TABLE
    `Ticket` ADD CONSTRAINT `ticket_passenger_id_foreign` FOREIGN KEY(`passenger_id`) REFERENCES `Passenger`(`passenger_id`);