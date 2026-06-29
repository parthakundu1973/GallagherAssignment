
import ErrorMessage from "../Components/ProbabilityForm/ErrorMessage";
import ProbabilityForm from "../Components/ProbabilityForm/ProbabilityForm";
import ProbabilityResult from "../Components/ProbabilityForm/ProbabilityResult";
import { useProbabilityCalculator } from "./probability/hooks/useProbabilityCalculator";

export default function ProbabilityPage() {
    const { result, error, calculate } = useProbabilityCalculator();

    return (
        <div>
            <ProbabilityForm onCalculate={calculate} />
            {error && <ErrorMessage message={error} />}
            {result && <ProbabilityResult result={result} />}
        </div>
    );
}