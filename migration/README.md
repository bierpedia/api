# Migration from wordpress database to sane (postgres) model

Requirements: docker, pgloader, bash

* run `./mysql_to_postgres.sh path/to/wordpress/dump.sql migration.sql ../docker/database` to obtain `bierpedia.dump`
* setup new database container (adjust port): `docker run -d -p 5437:5432 --name bierpedia.data.db --env POSTGRES_HOST_AUTH_METHOD=trust bierpedia.db`
* in `bierpedia_api/BierpediaApi` run `dotnet ef database update`
* restore data: `docker exec -i bierpedia.data.db pg_restore -U bierpedia -d bierpedia -ae -1 --disable-triggers < ./bierpedia.dump`

