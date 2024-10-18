import { useParticipantProperty } from "@daily-co/daily-react";
import './username.css'

interface UsernameProperties {
    id: string
    isLocal: boolean
}

const Username: React.FC<UsernameProperties> = ({ id, isLocal }) => {
    const username = useParticipantProperty(id, 'user_name')

    return (
        <div className='username'>
            {username || id} {isLocal && '(you)'}
        </div>
    )
}

export default Username