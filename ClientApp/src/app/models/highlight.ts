export interface Highlight {
    title: string;
    embed: string;
    url: string;
    thumbnail: string;
    competition: ScoreBatCompetition;
}

interface ScoreBatCompetition {
    name: string;
}

