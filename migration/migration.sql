# Migrate data from wordpress database to new model
#
# breweries
create table bierpedia.breweries
select breweries.term_id as id,
       breweries.name    as name,
       breweries.slug    as slug,
       tt.description    as description,
       tt.parent         as country_id
from wp_terms as breweries,
     wp_term_taxonomy as tt
where tt.taxonomy = 'brauerei'
  and tt.term_id = breweries.term_id
  and tt.parent != 0;

# countries
create table bierpedia.countries select country.term_id as id,
       country.name as name,
       country.slug as slug,
       tt.description as description
from wp_terms as country,
     wp_term_taxonomy as tt
where tt.taxonomy = 'brauerei' and
      tt.term_id = country.term_id and
      tt.parent = 0;

# style
create table bierpedia.styles select
        style.term_id as id,
        style.name as name,
        style.slug as slug,
        tt.description as description,
IF(tt.parent = 0, NULL, tt.parent) as parent_id
from wp_terms as style,
     wp_term_taxonomy as tt
where tt.taxonomy = 'biersorte' and
      tt.term_id = style.term_id;

# concern
create table bierpedia.concerns select concern.Id as id,
       concern.post_title as name,
       concern.post_name as slug,
       concern.post_content as description
from wp_posts as concern
where concern.post_type = 'konzern' and
      concern.post_status = 'publish';

# beers
create table bierpedia.beers select beer.Id as id,
       beer.post_title as name,
       beer.post_name as slug,
       beer.post_content as description,
       cast(m.meta_value as unsigned) as concern_id,
       # to be safe, 2 digits left and right of decimal
       cast(m2.meta_value as decimal(4,2)) as abv
from wp_posts as beer
    # concern is stored in postmeta
    JOIN wp_postmeta as m
        ON m.post_id = beer.id
    # alc is stored in postmeta
    JOIN wp_postmeta as m2
        ON m2.post_id = beer.id
    where
        m.meta_key = 'bierpedia_bier_meta_konzern' and
        m2.meta_key = 'bierpedia_bier_meta_alc' and
        beer.post_type = 'bier' and
        beer.post_status = 'publish';

# beers <-> breweries
create table bierpedia.beer_breweries select beers.id as beer_id,
       tt_brewery.term_id as brewery_id
from bierpedia.beers as beers,
     wp_terms as breweries,
     wp_term_taxonomy as tt_brewery,
     wp_term_relationships as rel
where
    beers.id = rel.object_id and
    rel.term_taxonomy_id = tt_brewery.term_taxonomy_id and
    tt_brewery.taxonomy = 'brauerei' and
    tt_brewery.term_id = breweries.term_id;

# beers <-> styles
create table bierpedia.beer_styles select beers.id as beer_id,
       styles.term_id as style_id
from bierpedia.beers as beers,
     wp_terms as styles,
     wp_term_taxonomy as tt_styles,
     wp_term_relationships as rel
where
    beers.id = rel.object_id and
    rel.term_taxonomy_id = tt_styles.term_taxonomy_id and
    tt_styles.taxonomy = 'biersorte' and
    tt_styles.term_id = styles.term_id;

