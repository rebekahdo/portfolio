SELECT AVG(draft_pick_number) AS avg_pick, MAX(draft_pick_number) AS max_pick, MIN(draft_pick_number) AS min_pick
FROM nfl_draft_picks;
SELECT position, AVG(draft_pick_number) AS avg_pick, MAX(draft_pick_number) AS max_pick, MIN(draft_pick_number) AS min_pick
FROM nfl_draft_picks
GROUP BY position
HAVING COUNT(*) > 10;
SELECT player_name, year, position, draft_pick_number,
  CASE
    WHEN draft_pick_number <= 10 THEN 'Top 10'
    WHEN draft_pick_number <= 20 THEN '11-20'
    WHEN draft_pick_number <= 50 THEN '21-50'
    ELSE '51+'
  END AS draft_category
FROM nfl_draft_picks;
SELECT *
FROM nfl_draft_picks
WHERE (year = 2019 OR year = 2020) AND draft_pick_number <= 10;
SELECT *
FROM nfl_draft_picks
WHERE year = 2019 OR (year = 2020 AND draft_pick_number <= 10);
