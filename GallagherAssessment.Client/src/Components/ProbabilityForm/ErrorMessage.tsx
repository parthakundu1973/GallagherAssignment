import styles from "./ProbabilityForm.module.css";
interface Props {
	message: string;
}

function ErrorMessage({ message }: Props) {

	if (!message)
		return null;
	return (
		<p className={ styles.error} >
			{message}
		</p>
	)

}

export default ErrorMessage;