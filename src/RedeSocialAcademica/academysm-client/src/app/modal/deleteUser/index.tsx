import React from 'react';
import DeleteUserViewServices from '../../services/deleteUserViewServices';
import navigateTo from '../../../infra/navigation/navigation';

interface DeleteUserModalProps {
    id: string
    isOpen: boolean
    onClose: () => void
}

const DeleteUserModal: React.FC<DeleteUserModalProps> = ({ id, isOpen, onClose }) => {
    const deleteUserVS: DeleteUserViewServices = new DeleteUserViewServices()

    const deleteUser = async () => {
        await deleteUserVS.deleteUser(id)

        alert('Seus Dados Foram Excluídos com Sucesso!')

        navigateTo('/Login')
    }

    if (!isOpen) return null

    return (
        <div className='modal'>
            <div className='modal-container'>
                <div className='modalHeader'>
                    <button
                        className='modal-close-button'
                        onClick={onClose}>
                        X
                    </button>
                </div>
                <h1>Você tem certeza que quer excluir seus dados?</h1>
                <button
                    className='medium bordo'
                    onClick={deleteUser}>
                    Sim
                </button>
                <button
                    className='medium verde'
                    onClick={onClose}>
                    Não
                </button>
            </div>
        </div>
    )
}

export default DeleteUserModal