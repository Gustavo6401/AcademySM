import React, { useState } from "react";
import FormStep1 from "../../components/createUser/formCreateUserStep1/Step1";
import FormStep2 from "../../components/createUser/formCreateUserStep2/Step2";
import FormStep3 from '../../components/createUser/formCreateUserStep3/Step3'
import NavbarWhite from "../../components/navbarWhite/Index";
import FormProvider from "../../context/createUserFormContext";
import './createUser.css'
import FormStep4 from "../../components/createUser/formCreateUserStep4/Step4";
import FormStep5 from "../../components/createUser/formCreateUserStep5/Step5";

type Steps = {
    label: string
    component: ({ nextStep, skipStep }) => JSX.Element
}

// en - Code generated with ChatGPT.
// pt-BR - Código Gerado com o ChatGPT
const steps: Array<Steps> = [
    {
        label: 'Passo 1',
        component: ({ nextStep }) => (
            <FormStep1 nextStep={nextStep} />
        )
    },
    {
        label: 'Passo 2',
        component: ({ nextStep, skipStep }) => (
            <FormStep2 nextStep={nextStep} skipStep={skipStep} />
        )
    },
    {
        label: 'Passo 3',
        component: ({ nextStep, skipStep }) => (
            <FormStep3 nextStep={nextStep} skipStep={skipStep} />
        )
    },
    {
        label: 'Passo 4',
        component: ({ nextStep, skipStep }) => (
            <FormStep4 nextStep={nextStep} skipStep={skipStep} />
        )
    },
    {
        label: 'Passo 5',
        component: () => (
            <FormStep5 /> // Create User Button is in the 5th step - O botão de criar usuário está no passo 5.
        )
    }
]

export default function CreateUser() {    
    const [currentStep, setCurrentStep] = useState(0)

    const nextStep = () => setCurrentStep((prev: number) => Math.min(prev + 1, steps.length - 1))
    const skipStep = () => setCurrentStep((prev: number) => Math.min(prev + 1, steps.length - 1))

    const CurrentComponent = steps[currentStep].component
    // en - End of generated code with ChatGPT.
    // pt-Br - Fim do código gerado com ChatGPT.

    const NextStepButton = () => {
        return (
            <button
                className='medium azul-escuro'
                onClick={nextStep}
                disabled={currentStep === steps.length - 1}
            >
                Avançar
            </button>
        )
    }

    const PrevStepButton = () => {
        return (
            <button
                className='medium branco'
                onClick={skipStep}
                disabled={currentStep === 0}
            >
                Pular
            </button>
        )
    }

    return (
        <div>
            <NavbarWhite />
            <div className="createUser">
                <FormProvider>
                    <CurrentComponent nextStep={<NextStepButton />} skipStep={<PrevStepButton />} />
                </FormProvider>
            </div>
        </div>
    )
}