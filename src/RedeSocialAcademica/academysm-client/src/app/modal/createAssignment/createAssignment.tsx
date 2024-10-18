import { useState } from "react"
import CadastroTarefasViewServices from "../../services/cadastroTarefasViewServices"

interface CreateAssignmentProperties {
    groupId: string
    isOpen: boolean
    onClose: () => void
}

const services: CadastroTarefasViewServices = new CadastroTarefasViewServices()

const CadastroTarefa: React.FC<CreateAssignmentProperties> = ({ isOpen, onClose, groupId }) => {
    const [title, setTitle] = useState<string>('')
    const [dueDate, setDueDate] = useState<Date>(new Date())
    const [noteValue, setNoteValue] = useState<number>(0)

    const create = async (): Promise<void> => {
        const response: string = await services.create(title, dueDate, noteValue, groupId)

        alert(response)
    }

    const handleDateChange = (e: React.FormEvent<HTMLInputElement>, dateStateFunction: Function) => {
        const valor: string = e.currentTarget.value
        const dateValue: Date = new Date(valor)

        dateStateFunction(dateValue)
    }

    const handleNumberChange = (e: React.FormEvent<HTMLInputElement>, numberStateFunction: Function) => {
        const valor: string = e.currentTarget.value
        const numberValue: number = Number.parseInt(valor)

        numberStateFunction(numberValue)
    }

    if (!isOpen) return null

    return (
        <div className='modal'>
            <div className='modal-container'>
                <div className='modalHeader'>
                    <h2 className='modal-title'>Cadastro de Tarefas</h2>
                    <button className='modal-close-button' onClick={onClose}>X</button>
                </div>
                <div className='cadastroTarefas'>
                    <div className='componentIsolator-1'>
                        <input className='formInputType-1' type='text' placeholder='Título' onChange={e => setTitle(e.target.value)} />
                    </div>
                    <div className='componentIsolator-1'>
                        <input className='formInputType-1' type='date' placeholder='Data de Entrega' onChange={e => handleDateChange(e, setDueDate)} />
                    </div>
                    <div className='componentIsolator-1'>
                        <input className='formInputType-1' type='number' placeholder='Nota' onChange={e => handleNumberChange(e, setNoteValue)} />
                    </div>
                    <div className='componentIsolator-1'>
                        <button className='button-medium azul-escuro' onClick={create}>Cadastre Aqui</button>
                    </div>
                </div>
            </div>
        </div>
    )
}

export default CadastroTarefa