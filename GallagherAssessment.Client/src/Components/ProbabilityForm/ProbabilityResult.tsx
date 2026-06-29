interface Props {
	result: number | null;
}

function ProbabilityResult({ result }: Props) {
	if (result === null)
		return null;
	return (
		<h2>
			Result: {result}
		</h2>
	);
}

export default ProbabilityResult;
