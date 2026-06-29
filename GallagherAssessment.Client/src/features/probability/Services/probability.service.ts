import { calculateProbability } from "../../../api/probabilityApi";
import type { ProbabilityRequest, ProbabilityResponse } from "../types/probability.types";

export const probabilityService = {
    calculate: async (req: ProbabilityRequest): Promise<ProbabilityResponse> => {
        return await calculateProbability(req);
    },


};