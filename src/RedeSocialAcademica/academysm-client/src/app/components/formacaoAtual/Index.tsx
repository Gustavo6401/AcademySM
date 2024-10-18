interface GrauFormacaoProps {
    cssClass: string
    onChange: (e: React.ChangeEvent<HTMLSelectElement>) => void
}

const GrauFormacao: React.FC<GrauFormacaoProps> = ({ cssClass, onChange }) => {
    return (
        <select className={cssClass} onChange={onChange}>
            <option value='Ensino Fundamental 1'>Ensino Fundamental 1</option>
            <option value='Ensino Fundamental 2'>Ensino Fundamental 2</option>
            <option value='Ensino Médio'>Ensino Médio</option>
            <option value='Ensino Médio Técnico'>Ensino Médio Técnico</option>
            <option value='Ensino Superior'>Ensino Superior</option>
            <option value='Pós-Graduação'>Pós-Graduação</option>
            <option value='Mestrado'>Mestrado</option>
            <option value='Doutorado'>Doutorado</option>
        </select>
    );
}

export default GrauFormacao;