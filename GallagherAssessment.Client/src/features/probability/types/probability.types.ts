export type Operation = "CombinedWith" | "Either";

export interface ProbabilityRequest {
    pA: number;
    pB: number;
    operation: string;
}

export interface ProbabilityResponse {
    result: number;
}