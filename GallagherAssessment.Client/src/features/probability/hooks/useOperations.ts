
import { useQuery } from "@tanstack/react-query";
import { API_ENDPOINTS } from "../../../config/api";
import type { Operation } from "../types/operationList";

export const fetchOperations = async (): Promise<Operation[]> => {
    const response = await fetch(API_ENDPOINTS.getOperationList);

    if (!response.ok) {
        throw new Error("Failed to load operations");
    }

    return response.json();
};

export const useOperations = () =>
    useQuery({
        queryKey: ["operations"],
        queryFn: fetchOperations,
    });