import { useEffect, useState } from "react";
import styles from "./ProbabilityForm.module.css";

import { useOperations } from "../../features/probability/hooks/useOperations";
import { validateProbabilities } from "../../features/probability/utils/validation";

interface ProbabilityFormProps {
    onCalculate: (pA: number, pB: number, operation: string) => void;
}
export default function ProbabilityForm({ onCalculate }: ProbabilityFormProps) {
    const [pA, setPA] = useState("");
    const [pB, setPB] = useState("");
    const [error, setError] = useState("");
    const [operation, setOperation] = useState("");


    const {
        data: operations = [],
        error: queryError,
        isLoading,
    } = useOperations();

    useEffect(() => {
        if (operations.length > 0 && !operation) {
            setOperation(operations[0].key);
        }
    }, [operations]);

    const handleSubmit = () => {
        const a = parseFloat(pA);
        const b = parseFloat(pB);
        const validation = validateProbabilities(a, b);
        if (validation) {
            setError(validation);
            return;
        }

        setError("");
        onCalculate(a, b, operation);
    };

    return (
        <div className={styles.container}>
            <h2>Probability Calculator</h2>

            <input
                type="number"
                min="0"
                max="1"
                step="0.01"
                placeholder="P(A) e.g. 0.5"
                value={pA}
                onChange={(e) => setPA(e.target.value)}
                className={styles.input}
            />

            <input
                type="number"
                min="0"
                max="1"
                step="0.01"
                placeholder="P(B) e.g. 0.5"
                value={pB}
                onChange={(e) => setPB(e.target.value)}
                className={styles.input}
            />

            <select
                value={operation}
                onChange={(e) => setOperation(e.target.value)}
                className={styles.select}
            >
                {operations.map((op) => (
                    <option key={op.key} value={op.key}>
                        {op.label}
                    </option>
                ))}
            </select>

            <button onClick={handleSubmit} className={styles.button}>
                Calculate
            </button>

            {error && <p className={styles.error}>{error}</p>}

            {queryError && (
                <p className={styles.error}>
                    Could not load operations dropdown
                </p>
            )}

            {isLoading && <p>Loading operations...</p>}
        </div>
    );
}