import { useState } from "react"
import EnviarTarefaViewServices from "../../services/enviarTarefaViewServices"
import navigateTo from "../../../infra/navigation/navigation"

interface EnviarTarefaProperties {
    isOpen: boolean
    onClose: () => void
    tarefaId: string
}

const EnviarTarefa: React.FC<EnviarTarefaProperties> = ({ isOpen, onClose, tarefaId }) => {
    const [selectedFile, setSelectedFile] = useState<File | null>(null)

    var services: EnviarTarefaViewServices = new EnviarTarefaViewServices()

    const enviarTarefa = async () => {
        var response: string = ''

        console.log(selectedFile)

        if (selectedFile) {


            response = await services.create(selectedFile, tarefaId)
        }

        alert(response)

        if (response === 'Para que a Tarefa seja enviada, é necessário que o usuário esteja logado.') {
            navigateTo('/')
        }
    }

    const handleFileChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        const file: File | undefined = e.target.files?.[0]
        console.log(file?.name)

        if (file) {           
            setSelectedFile(file)
        }
    }

    if(!isOpen) return null

    return (
        <div className='modal'>
            <div className='modal-container'>
                <div className='modalHeader'>
                    <h2 className='modal-title'>Cadastro de Tarefa</h2>
                    <button className='modal-close-button' onClick={onClose}>X</button>
                </div>
                <div className='envioTarefas'>
                    <div className='componentIsolator-1'>
                        <label>Envie aqui a Sua Tarefa</label>
                        <input className='formInputType-1' type='file' onChange={handleFileChange} />
                    </div>
                    <div className='componentIsolator-1'>
                        <button className='button-medium azul' onClick={enviarTarefa}>Enviar Tarefa</button>
                    </div>
                </div>
            </div>
        </div>
    )
}

export default EnviarTarefa