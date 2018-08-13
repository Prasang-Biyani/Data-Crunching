# Data-Crunching
Data Crunching using 32 Million data (.tsv) using C#  

There are three raw database files which contains ID(s), Username(s), Email(s), Hash Password(s), Password(s)(Fake!). 
Goal is to create a new table (or file) using ID, username, email, hash_password, password with their matching creditinals. 

Three files are as follows:
1) ip_1m.tsv - 1 million records of users with id, ip 
2) Plain_32m.tsv – 32 million records of users with email, plaintext_password (Luckily!) 
3) User_email.hash.1m.tsv – 1 million records of users with id, username, email, hashed_password 
