#!/bin/bash
set -e

USAGE="Usage: mysql_to_postgres.sh <WP_DUMP> <MIGRATION_SQL> <PG_DOCKER"

if [ -z "$1" ] || [ -z "$2" ] || [ -z "$3" ]
then
    echo $USAGE
    exit 1
fi

WP_DUMP=$1
MIGRATION_SQL=$2
PG_DOCKER=$3


MYSQL_NAME="bierpedia_mysql_migration"
MYSQL_WP_DBNAME="DB3018878"
MYSQL_DBNAME="bierpedia"
PG_NAME="bierpedia_pg_migration"
PG_TAG="bierpedia.db"


echo "Create mysql container" 
docker create --name $MYSQL_NAME --env MYSQL_ROOT_PASSWORD=root -p 3307:3306 mysql:5.7
docker start $MYSQL_NAME


echo "Wait for mysql to come up"
while ! docker exec $MYSQL_NAME mysql -proot -e 'status' &> /dev/null ; do echo "Wait ..."; sleep 3; done

echo "Restore database dump"
docker exec -i $MYSQL_NAME mysql -proot -e "CREATE DATABASE $MYSQL_DBNAME;"
docker exec -i $MYSQL_NAME mysql -proot $MYSQL_DBNAME < $WP_DUMP 

echo "Create intermediate tables"
docker exec -i $MYSQL_NAME mysql -proot $MYSQL_WP_DBNAME < $MIGRATION_SQL

echo "Create postgres container"
docker build $PG_DOCKER --tag $PG_TAG 
docker create --name $PG_NAME --env POSTGRES_HOST_AUTH_METHOD=trust -p 5433:5432 $PG_TAG
docker start $PG_NAME

echo "Wait for postgres to come up"
while ! docker exec -i $PG_NAME psql -U bierpedia -c '\l' &> /dev/null ; do echo "Wait...";  sleep 1; done

echo "Migrating data to postgres"
docker run --rm --name pgloader dimitri/pgloader:latest pgloader mysql://root:root@host.docker.internal:3307/bierpedia postgresql://bierpedia:bierpedia@host.docker.internal:5433/bierpedia

echo "Dumping data from postgres"
docker exec -i $PG_NAME pg_dump -Fc -U bierpedia bierpedia > bierpedia.dump

echo "Deleting mysql container"
docker stop $MYSQL_NAME
docker rm $MYSQL_NAME

echo "Deleting postgres container"
docker stop $PG_NAME
docker rm $PG_NAME
