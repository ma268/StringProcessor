 SELECT businesses.business				 AS [Business],
       Isnull(premises.streetno, '')     AS [StreetNo],
       premises.street					 AS [Street],
       premises.postcode				 AS [PostCode],
       Isnull(Footfall.footfallcount, 0) AS [FootfallCount]
FROM   premises
       --Assumption: All business id in the premisses table will exist in the business table therefore and inner join is used as is more efficient
       INNER JOIN businesses
               ON premises.businessid = businesses.id
       --left join used as we want to display premises that do not have footfall alongside those that do
       LEFT JOIN (SELECT premisesid,
                         Sum([count]) AS [FootfallCount]
                  FROM   footfall
                  GROUP  BY premisesid
                 -- groub by used to calculate total footfall over the weeks provided
                 ) footfall
              ON footfall.premisesid = premises.id  


-- This displays a total number of footfall over the week no 32-34
-- If a different period is requested i would add a where statement to my query in the footfall group by section
-- I am only displaying requested columsn but it also be useful to indicate the following:
--- an average weekly footfall 
--- no of weeks with no footfall at all
--- week with the highest footfall (if monthly data is available or the weeks are dated a monthly footfall count could also be calculated)
--- max footfall and min footfall