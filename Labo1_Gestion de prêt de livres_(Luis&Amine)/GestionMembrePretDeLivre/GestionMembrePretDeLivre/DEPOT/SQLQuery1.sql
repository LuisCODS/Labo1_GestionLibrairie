select LivreID, Titre from Livre 
where LivreID NOT IN (select LivreID from Pret)