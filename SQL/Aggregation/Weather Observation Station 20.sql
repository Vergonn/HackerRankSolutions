SELECT ROUND(s.lat_n, 4) FROM station AS s WHERE (SELECT ROUND(COUNT(s.id)/2) - 1 FROM station)
IN (SELECT COUNT(s1.id) FROM station AS s1 WHERE s1.lat_n > s.lat_n);