interface LivescoreInfo {
    match_id: number;
    country_name: string;
    league_name: string;
    match_date: string;
    match_status: string;
    match_time: string;
    match_hometeam_name: string;
    match_hometeam_score: string;
    match_awayteam_name: string;
    match_awayteam_score: string;
    match_live: string;
    goalscorer: GoalScorer[];
}

interface GoalScorer {
    time: string;
    home_scorer: string;
    score: string;
    away_scorer: string;
}

export { LivescoreInfo, GoalScorer };


