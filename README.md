# Band Tracker

#### _Keep track of which venues bands perform at_

#### By _**Katherine Matthews**_

## Description

_This webpage keeps track of music venues and the bands that perform at each one. User can create bands and venues, which are then kept organized in a SQL database. Bands can be associated with multiple venues and venues can be associated with multiple bands. Upon clicking on a single venue, the user can update the venue's name, as well as see which bands have played or are scheduled to play at that venue. https://katherinemat.github.io/band-tracker/_

## Setup/Installation Requirements

#### Create Databases
In SQLCMD:  
    > CREATE DATABASE band_tracker;
    > GO  
    > USE band_tracker;  
    > GO  
    > CREATE TABLE venues (id INT IDENTITY(1,1), name VARCHAR(255));  
    > GO  
    > CREATE TABLE bands (id INT IDENTITY(1,1), name VARCHAR(255));  
    > GO
    > CREATE TABLE bands_venues (id INT IDENTITY(1,1), band_id INT, venue_id INT);
    > GO

In MSSQL:
1. right-click database > Tasks > Back Up > Ok
- right-click database > Tasks > Restore > Database > in Destination Database replace band_tracker with band_tracker_test > Ok

*_Requires DNU, DNX, MSSQL, and Mono_
* Clone to local machine
* Use command "dnu restore" in command prompt/shell
* Use command "dnx kestrel" to start server
* Navigate to http://localhost:5004

## Specifications

Band:
1. Create band object; input: new band called CCR; output: CCR
- Create band that has played at certain venues; input: CCR has played at Hollywood Bowl; output: CCR, Hollywood Bowl
- Get all venues for a single band; input: CCR; output: Hollywood Bowl, Irvine Amphitheater, Radio City Music Hall
- Add venue for a band using a join statement; input: CCR add Santa Barbara Bowl; output: Hollywood Bowl, Irvine Amphitheater, Radio City Music Hall, Santa Barbara Bowl

Venue:
1. Create venue object; input: new orchestra hall; output: orchestra hall
- Get venue; input: select Radio City; output: Radio City
- Update name of venue; input: Radi City -> Radio City Music Hall; output: Radio City Music Hall
- Delete individual venues; input: delete, Radio City Music Hall; output: all venues are Hollywood Bowl and Irvine Amphitheater
- View all bands that have played at an individual venue; input: Hollywood Bowl; output: Taylor Swift, CCR, Queen
- User can add a new band to a venue on the venue's individual page; input: Hollywood Bowl, B52s; output: Taylor Swift, CCR, Queen, B52s

## Technologies Used

* _C#_
* _SQL_
* _HTML_
* _CSS_
* _Materialize_

### License

*This project is licensed under the MIT license.*

Copyright (c) 2017 **_Katherine Matthews_**
