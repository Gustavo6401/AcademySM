import { useState } from 'react';
import EducationalBackground from '../../../domain/models/apis/user/educationalBackground';
import Navbar from '../../components/navbar';
import './UserProfile.css'

function UserProfile() {
    const [educationalBackgrounds, setEducationalBackgrounds] = useState<Array<EducationalBackground | undefined>>(undefined)

    return (
        <div>
            <Navbar />
            <div>
                
            </div>
        </div>
    );
}

export default UserProfile;