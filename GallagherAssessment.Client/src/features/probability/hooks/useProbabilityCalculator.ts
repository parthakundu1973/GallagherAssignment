import { useState } from "react";
import { probabilityService } from "../Services/probability.service";

export function useProbabilityCalculator() {
    const [result, setResult] = useState<number | null>(null);
    const [error, setError] = useState("");

    const calculate = async (pA: number, pB: number, operation: string) => {
        try {
            setError("");

            const res = await probabilityService.calculate({
                pA,
                pB,
                operation,
            });

            setResult(res.result);
        } catch {
            setError("Calculation failed");
        }
    };

    return { result, error, calculate };
}