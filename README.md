This is my solution to the second exercise I participated in while studying at Lexicon. 
The exercise description can be seen below; it is written in Swedish, and I will not translate it.

# C# Övning – Flöde via loopar och strängmanipulation

> **OBS:** Resultatet av övningen ska visas för lärare och godkännas innan den kan anses vara genomförd.

Övningen kan skrivas helt i `Program`-klassen med menyn i `Main`-metoden.

---

## 🧭 Huvudmeny

Skapa en huvudmeny för programmet som håller det vid liv och informerar användaren.

### Att göra:
1. Informera användaren att de har kommit till huvudmenyn och att de navigerar genom att skriva siffror.
2. Skapa en `switch`-sats med minst två `case`:
   - `case "0"` stänger ner programmet.
   - `default` visar meddelande om ogiltig input.
3. Skapa en oändlig iteration med en `bool` och `while-loop` som håller programmet vid liv tills användaren avslutar.
4. Bygg ut menyn med alternativ för att exekvera de övriga övningarna.

---

## 1️⃣ Menyval 1: Ungdom eller pensionär

Du ska implementera ett program åt en teoretisk biograf som avgör biljettpris baserat på ålder.

### Funktion:
1. Användaren anger sin ålder som ett heltal.
2. Programmet avgör pris baserat på åldern:
   - Under 20 år: `Ungdomspris: 80kr`
   - Över 64 år: `Pensionärspris: 90kr`
   - Annars: `Standardpris: 120kr`

Använd en nästlad `if-sats`.

### Gruppfunktion:
Lägg till ett alternativ (t.ex. `case "2"`) där användaren anger hur många personer som ska gå på bio, därefter anger åldern för varje person. Programmet visar:
- Antal personer
- Totalkostnad för sällskapet

---

## 2️⃣ Menyval 2: Upprepa tio gånger

Använd en `for-loop` för att upprepa en sträng tio gånger.

### Funktion:
1. Användaren skriver in en godtycklig text.
2. Programmet sparar den som en variabel.
3. Programmet skriver ut texten **tio gånger på rad utan radbrytning** (t.ex. `1. Input, 2. Input, ...`).

Lägg till detta som `case "3"` i huvudmenyn.

---

## 3️⃣ Menyval 3: Det tredje ordet

Använd `string.Split` för att plocka ut ord ur en mening.

### Funktion:
1. Användaren skriver en mening med minst tre ord.
2. Programmet delar upp strängen med `.Split(' ')`.
3. Det tredje ordet (index 2) skrivs ut.

Lägg till detta som `case "4"` i huvudmenyn.

---

## 📝 Dokumentera

Kommentera koden noggrant så att både du och andra kan förstå den i framtiden.

---

## ⭐ Extra uppgifter (för den som har tid över)

1. Validera all input från användaren så att programmet inte kraschar.
2. Barn under 5 år och pensionärer över 100 år går gratis.
3. Hantera flera mellanslag i rad i del 3.
4. Lägg till något du själv tycker verkar intressant eller vill träna mer på!

---

**Lycka till! 💻**
