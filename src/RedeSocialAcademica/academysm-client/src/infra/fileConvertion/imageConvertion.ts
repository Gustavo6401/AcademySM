export default async function ImageConvertion(file: File): Promise<Blob> {
    const img = new Image()
    img.src = URL.createObjectURL(file)

    return new Promise<Blob | undefined>((resolve) => {
        img.onload = () => {
            const canvas: HTMLCanvasElement = document.createElement('canvas')
            canvas.width = img.width
            canvas.height = img.height

            const ctx: CanvasRenderingContext2D | null = canvas.getContext('2d')
            ctx?.drawImage(img, 0, 0)

            canvas.toBlob((blob) => {
                resolve(blob || undefined) // Retorna o blob convertido ou undefined caso falhe
            }, 'image/webp')
        };

        img.onerror = () => resolve(undefined) // Em caso de erro ao carregar a imagem
    });
}