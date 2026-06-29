import { API_ENDPOINTS } from "../config/api";

export async function calculateProbability(req: {
    pA: number;
    pB: number;
    operation: string;
}) {
    const res = await fetch(API_ENDPOINTS.calculateProbability, {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(req),
    });

    if (!res.ok) {
        throw new Error("API Error");
    }

    return res.json();
}