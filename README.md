# izdaja-ponudb
Projekt03

Gradbeno podjetje ima veliko NAROČIL ZA STORITVE, KI JIH OPRAVLJA. Zato bi rado imelo sistem, kjer bi se vedelo katera vsa naročila je prejelo in od koga ... Spodaj je naročilo s strani podjetja:
Veliko ponudb moram vsak dan izdati in na koncu ne vem, katera ponudba je bila izdana, katera sprejeta ... Rad bi imel sistem, ki bi vsako prejeto ponudbo zavedel v sistem in jih dal status. Na začetku prejeto, potem, ko je ponudba izdana - status izdano, nato pa če je sprejeta ali zavrnjena. Za ponudbo želim vedeti, komu je izdana, kakšna je bila ponujena cena in opis ponudbe ter kdo od mojih delavcev jo je izdal.
Potem pa želim, da mi se kreira poročilo na nek poljuben interval, ki ga določim jaz, koliko ponudb je bilo izdanih in v katerih stanjih so te ponudbe. Lahko pa nastavim filtre stanje pondube, podjetje ali delavec.
Naj bo čim polj pregledno in da si bom lahko podatke izvozil v Excel.


# API
 Method - Post

## LOGIN
 URI - https://izdaja-ponudb.herokuapp.com/login.php

#### PARAMS
 username
 String

 password
 String

>Nazaj vrne id Uporabnika, ce uporabnika ni potem vrne NO USER

## REGISTER USER
 https://izdaja-ponudb.herokuapp.com/registration.php

#### PARAMS
 username
 String

 password
 String

 name
 String

 email
 String

 phone
 String