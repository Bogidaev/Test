Для смены на формата XML или JSON в hedere запроса надо отправить для: 
JSON - Content-Type application/json 
XML - Content-Type application/xml

http://localhost:53929/api/users - Получение списка всех пользователей

http://localhost:53929/api/users/{id}  - Получение пользователя по id

http://localhost:53929/api/albums -  Получение списка всех альбомов

http://localhost:53929/api/albums/{id} - Получение альбома по id

http://localhost:53929/api/albums/GetUserAlbums/{userId} - Получение всех альбомов одного пользователя