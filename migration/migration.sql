# Migrate data from wordpress database to new model
# 
# Run this inside the wordpress database and dump the tables with INSERT SQL statements
# Fix the schema by substituting s/DB3018878/bierpedia/g 
# The order in here is the order in which the tables must be restored
# To restore the beer_types run
#      `SET session_replication_role = 'replica';` 
# before restoring, and 
#      `SET session_replication_role = 'origin';`
# after restoring to disable foreign key checks during the restore.
# (Necessary because of the selfreference)

# breweries
create table breweries select breweries.term_id as id,
       breweries.name as name,
       breweries.slug as slug,
       tt.parent as country_id
from wp_terms as breweries,
     wp_term_taxonomy as tt
where tt.taxonomy = 'brauerei' and
      tt.term_id = breweries.term_id and
      tt.parent != 0;

# countries
create table countries select country.term_id as id,
       country.name as name,
       country.slug as slug,
       tt.description as description
from wp_terms as country,
     wp_term_taxonomy as tt
where tt.taxonomy = 'brauerei' and
      tt.term_id = country.term_id and
      tt.parent = 0;

# beertype
create table beer_types select beertype.term_id as id,
       beertype.name as name,
       beertype.slug as slug,
       tt.description as description,
       IF(tt.parent = 0, NULL, tt.parent) as parent_id
from wp_terms as beertype,
     wp_term_taxonomy as tt
where tt.taxonomy = 'biersorte' and
      tt.term_id = beertype.term_id;

# beers
create table beers select beer.Id as id,
       beer.post_title as name,
       beer.post_name as slug,
       beer.post_content as description
from wp_posts as beer
where beer.post_type = 'bier' and
      beer.post_status = 'publish';

# beers <-> breweries
create table beer_breweries select beers.id as beer_id,
       tt_brewery.term_id as brewery_id
from beers,
     wp_terms as breweries,
     wp_term_taxonomy as tt_brewery,
     wp_term_relationships as rel
where
    beers.id = rel.object_id and
    rel.term_taxonomy_id = tt_brewery.term_taxonomy_id and
    tt_brewery.taxonomy = 'brauerei' and
    tt_brewery.term_id = breweries.term_id;

# beers <-> beer_types
create table beer_beer_types select beers.id as beer_id,
       beer_types.term_id as beer_type_id
from beers,
     wp_terms as beer_types,
     wp_term_taxonomy as tt_beer_types,
     wp_term_relationships as rel
where
    beers.id = rel.object_id and
    rel.term_taxonomy_id = tt_beer_types.term_taxonomy_id and
    tt_beer_types.taxonomy = 'biersorte' and
    tt_beer_types.term_id = beer_types.term_id

