cd ../
for /F %i in ('dir /A:-D /S /B') do move %i %i.bak