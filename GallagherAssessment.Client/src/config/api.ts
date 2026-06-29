const API_BASE = import.meta.env.VITE_API_URL ?? "https://localhost:7001";
export const API_ENDPOINTS = {
    calculateProbability: `${API_BASE}/api/probability/calculate`,
    getOperationList: `${API_BASE}/api/probability/operations`
}
