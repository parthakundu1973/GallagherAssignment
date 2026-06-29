export function validateProbabilities(a: number, b: number): string {
    if (isNaN(a) || isNaN(b))
        return "Please enter valid numbers";

    if (a < 0 || a > 1 || b < 0 || b > 1)
        return "Probabilities must be between 0 and 1";

    return "";
}   