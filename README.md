# Why must passwords not be stored as plain text ? 
Because if our database gets hacked or leaked, every user's actual password is stolen instantly. 
Then those same passwords can be used to hijack their accounts on other websites, since people always reuse passwords

# Why is raw SHA-256 not a good choice for passwords ?
SHA-256 is a fast encryption algorithm. 
Because it's so fast, hackers can use modern GPUs to guess billions of combinations per second 
using precomputed "rainbow tables" or brute-force attacks, cracking simple passwords almost instantly.

# Why do we use salt ?
Salt is a unique, random string added to a password before hashing it. 
It forces identical passwords to have completely different hashes in the database. 
It protects against precomputed rainbow tables and makes mass password cracking harder, 
because each user must be attacked individually

# What is the difference between salt and pepper ?
Salt is unique for every user and is stored along with the hash inside the database.
Pepper is a secret key that is the same for all users, and it's kept outside the database entirely (like in the app's appsettings.json or environment variables). 
If the DB is leaked, the hashes still can't be cracked without the pepper.

# What is the difference between authentication and authorization ?
Authentication is verifying who you are (e.g., logging in with an email and password).
Authorization is checking what permissions you have after you're logged in (e.g. a regular user is logged in but cannot delete other users because they do not have the administrator role).

# Why is hiding a link in a view is not enough as security ?
Hiding a link only gives us "security through obscurity." Anyone can easily type the restricted URL (like /Dashboard/Admin) directly into the browser address bar. 
If there isn't an explicit controller check (like an [Authorize(Roles="Admin")] attribute) protecting the backend endpoint, they will get right in.

# Why can a "there is no such user" login message be a problem ?
It leaks information, which is called "user enumeration". 
It explicitly tells a hacker whether a specific email address exists in our system or not. 
A hacker can abuse this to fish for registered accounts and target them specifically. 
We should always use a generic message like "Invalid email or password."
